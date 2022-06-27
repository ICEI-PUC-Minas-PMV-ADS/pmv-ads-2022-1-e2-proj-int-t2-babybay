# Instalação do Site

O site foi hospedado no https://www.smarterasp.net.

<li><a href="src/README.md"> 

/-------------------CLASSE STARTUP--------------------------/

using app_babybay.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_babybay
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            // Configurando serviço de cookie (Padrão)
            // Cookie é o arquivo salvo no browser do cliente para configurar e salvar a informação do logout
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "/Usuarios/AccessDenied";   // Muda aqui /Account/AcessDenied
                    options.LoginPath = "/Usuarios/Login";              // Muda aqui /Account/Login
                });
            // Em AccessDenied, tem que criar um método IActionResult - não assíncrono - no controller usuário, e criar uma view para exibir a mensagem

            services.AddControllersWithViews();
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Midwares
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy(); // Inserido para cookie

            app.UseAuthentication(); // Inserido para autenticar usuário

            app.UseAuthorization();           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

/-------------------CLASSE PROGAM--------------------------/


using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace app_babybay
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/-------------------CLASSE USUARIO--------------------------/


using app_babybay.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public  int Id { get; set; }

        /* Dados pessoais */
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Favor informar o nome.")]
        [MinLength(3)]
        public string Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Favor informar a data de nascimento.")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(11), MinLength(11)]
        [Required(ErrorMessage = "Favor informar o CPF.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Favor informar o telefone.")]
        public string Telefone { get; set; }

        /* Endereço */
        [Required(ErrorMessage = "Favor informar a rua.")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Favor informar o bairro.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Favor informar a cidade.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Favor informar o estado.")]
        public Estado Estado { get; set; }

        /* Login */
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Favor informar o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Favor informar a senha.")]
        [MinLength(8)]     
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "Favor confirmar a senha.")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string ConfirmarSenha { get; set; }
    
      

        


   
        /* Navegação */
        public ICollection<Produto> Produtos { get; set; }     
        public ICollection<Troca> Trocas { get; set; }
        public ICollection<Anuncio> Anuncios { get; set; }

 

        // Instância de Carteira para passar ao UsuariosController 
        public Carteira CriarCarteira()
        {
            Carteira carteira = new Carteira();           
            return carteira;
        }
    }

    public enum Estado
    {
        Selecionar, 
        AC,
        AL,
        AP,
        AM,
        BA,
        CE,
        ES,
        DF,
        GO,
        MA,
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RJ,
        RN,
        RS,
        RO,
        RR,
        SC,
        SP,
        SE,
        TO       
    }
}

/-------------------CONTROLLER USUARIO--------------------------/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace app_babybay.Controllers
{
    [Authorize] // Rota somente usuários logados terão acesso
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Login View
        [AllowAnonymous]    // Rota pública
        public IActionResult Login()
        {
            return View();
        }

        // Login Validação     
        [HttpPost]
        [AllowAnonymous]    // Rota pública
        public async Task<IActionResult> Login([Bind("Email,Senha")] Usuario usuario)
        {
            // Percorre o BD de forma assíncrona e compara o Id passado no método com o Id presente no BD
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Email == usuario.Email);

            // Se null, exibe msg e volta pro login
            if (user == null)
            {
                ViewBag.Message = "Usuário ou senha inválidos";
                return View();
            }

            // Verifica se a senha inserida no login é igual a senha que existe no BD
            bool senhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);

            if (senhaOk)
            {
                // Credenciais so usuário para redirecionar ele a página desejada
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.NameIdentifier, user.Nome),
                };

                var userIdentify = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentify);

                // Configurações 
                // ExpireUtc serve para o login expirar, no caso foi definido para 7 dias
                // AllowRefresh - refresh da aplicação
                // IsPersistent para permanecer na seção
                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7),
                    IsPersistent = true
                };

                // Insere o usuário na seção da aplicação
                await HttpContext.SignInAsync(principal, props);
                return RedirectToAction("Index", "Usuarios");       // Configurar para direcionar a tela de menu
            }

            // A senha estiver incorreta, exibe na tela
            ViewBag.Message = "Usuário ou senha inválidos";
            return View();
        }

        // Logout - sair do sistema
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // Acesso negado (ver startup, configuração de cookies)
        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: Usuarios 
        public async Task<IActionResult> Index()        // Menu será a Index
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        public async Task<IActionResult> RedirecionarMenu()
		{
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Nome.Contains(User.Identity.Name));

            return RedirectToAction("Relatorio", "Usuarios", new { id = usuario.Id });
		}        

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Relatorio/5
        public async Task<IActionResult> Relatorio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(t => t.Produtos)
                .Include(t => t.Anuncios)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]    // Rota pública
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Cpf,Telefone,Rua,Bairro,Cidade,Estado,Email,Senha,ConfirmarSenha")] Usuario usuario)
        {         
           /*Aqui ele ira comparar se a senha e o confirmar senha são iguais,caos sejam ele da proseguimento a criação do usuários. Saso não sejam iguais, ele retorna a mesma página*/
            if (ModelState.IsValid && usuario.Senha == usuario.ConfirmarSenha)
            {
               // Procura email/cpf que seja igual ao email/cpf digitado
                var usuarioBanco = await _context.Usuarios.FirstOrDefaultAsync(m => m.Email == usuario.Email || m.Cpf == usuario.Cpf);

                if (usuarioBanco == null)   // Significa que não está cadastrado
                {
                    // Criptografia
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    usuario.ConfirmarSenha = BCrypt.Net.BCrypt.HashPassword(usuario.ConfirmarSenha);
                    
                    // Usuário context
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();

                    // Carteira context: Passando o usuario para pegar a chave estrangeira 
                    var carteira = usuario.CriarCarteira();
                    carteira.Usuario = usuario;
                    _context.Add(carteira);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                // Se não entrou acima, ou seja, se não tem cadastro, exibe a msg:
                ViewBag.Message = "O Email ou CPF já estão cadastrados.";
                return View();           
            }
            // Se a senha e confirma senha estão incorretas
            ViewBag.Message = "A senha não confere, verifique.";

            return View(usuario); //Caso ou estado do model esteja inválido ou as senhas estejam diferentes, ele retornara a a view do usuário(atual)
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Cpf,Telefone,Rua,Bairro,Cidade,Estado,Email,Senha,ConfirmarSenha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   // Acertar para comparação de senha do BD com o que o usuário digitou, para alterar                    
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    usuario.ConfirmarSenha = BCrypt.Net.BCrypt.HashPassword(usuario.ConfirmarSenha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(int id, string SenhaDelete)
        {

            if (SenhaDelete == null)
            {
                ViewBag.Message = "Por favor, insira a sua senha";
                return RedirectToAction("Delete");
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            bool senhaOk = BCrypt.Net.BCrypt.Verify(SenhaDelete, usuario.Senha);           

            if (senhaOk)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                ViewBag.Message = "Senha inválida,tente novamente";
                return RedirectToAction("Delete");
            }
        }


        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}


/-------------------CLASSE PRODUTO--------------------------/


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Produtos")]
    public class Produto
    {
        // GUARDA ROUPAS VAI ENTRAR COMO METODO
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória.")]
        public string Cor { get; set; }

        [Display(Name = "Idade da Criança")]
        [Required(ErrorMessage = "A idade é obrigatória.")]
        public int Idade { get; set; }

        [Display(Name = "Tempo de Uso em Meses")]
        [Required(ErrorMessage = "O tempo de uso é obrigatório.")]
        public int TempoUso { get; set; }

        [Display(Name = "Descrição do Produto")]
        [Required(ErrorMessage = "Favor inserir uma descrição do produto."), MaxLength(120)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tamanho é obrigatório")]
        public int Tamanho { get; set; }
                
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public Categoria Categoria { get; set; }

        public bool ProdutoCurtido { get; set; }
       /* public bool InteresseTroca { get; set; }

        Dictionary<int, string> listaInteressados = new Dictionary<int, string>();*/

        internal void Receber(int quantidade)
        {
            throw new NotImplementedException();
        }

        // Construtor que inicia o ProdutoCurtido com false
        public Produto()
        {
            ProdutoCurtido = false;                          
        }       

        public void CurtirProduto()/*Aqui um método para curtir o produto,sera chamado quando apertar o botão Curtir,static é para ele ser um membro de classe
       para que assim ele estem método possa ser chamado por outro método no controle*/
        {
            ProdutoCurtido = true;         
        }
        public void DescurtirProduto()//Aqui um método para descurtir o produto,sera chamado quando apertar o botão curtir denovo,ou quando apertar o botão descurtir(ver depois)
        {
            ProdutoCurtido = false;
        }    
         
        
    }

    public enum Categoria
    {         
        Camiseta,
        Short,
        Calça,
        Macacão,
        Calçado,
        Outros
    }

    //public enum Idade
    //{
    //    Zero = 0,
    //    Um = 1,
    //    Dois = 2, 
    //    Três = 3,
    //    Quatro = 4,
    //    Cinco = 5,
    //    Seis = 6,
    //    Outras = 7
    //}
}


/-------------------CONTROLLER PRODUTO--------------------------/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace app_babybay.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Produtos.Include(c => c.Usuario);

            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> MenuProduto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            
            return View(produto);
        }

        //public async Task<IActionResult> RedirecionarMenu()
        //{
        //    var produto = await _context.Produtos
        //        .FirstOrDefaultAsync(m => m.Nome.Contains(User.Identity.Name));

        //    return RedirectToAction("MenuProduto", "Produtos", new { id = usuario.Id });
        //}

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cor,Idade,TempoUso,Descricao,Tamanho,Categoria")] Produto produto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var usuario = await _context.Usuarios   // User Logado
                      .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);
                produto.Usuario = usuario; 
            }
            else
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();

               // return RedirectToAction("Index", "Usuarios");
                return RedirectToAction("Relatorio", "Usuarios", new { id = produto.UsuarioId });
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "id", "Nome", produto.UsuarioId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cor,Idade,TempoUso,Descricao,Tamanho,Categoria")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = await _context.Usuarios
                         .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);  // Acha o usuário
                    produto.Usuario = usuario;      // Setando o usuario encontrado no Usuario do produto 
                                                    // salvaUsuarioId = usuario.Id;

                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("RedirecionarMenu", "Usuarios");
            }

            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);

            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Relatorio", "Usuarios", new { usuario.Id });
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }

    }

}


/-------------------CLASSE CARTEIRA--------------------------/



using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Carteiras")]
    public class Carteira
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public int Saldo { get; private set; }

        public Carteira()
        {
            Saldo = 10;
        }

        public void Receber(int quantidade)
        {
            if (quantidade > 0)
            {
                if (quantidade == 10)
                {
                    Saldo += 3;
                }
                else if (quantidade == 20)
                {
                    Saldo += 6;
                }
                else if (quantidade == 30)
                {
                    Saldo += 12;
                }
            }
        }

        public bool ReceberBabycoinAnuncio(int quantidade)
        {
            if (quantidade < 0)
            {
                return false;
            }

            Saldo += quantidade;

            return true;
        } 

        public bool Retirar(int quantidade)
        {
            if (quantidade < 0 ||quantidade > Saldo)
            {
                return false;
            }
           
            Saldo -= quantidade;

            return true;
        }

        public void Transferir(int quantidade, Carteira carteiraDestino)
        {
            if (quantidade < 0)
            {
                return;
            }

            Retirar(quantidade);
            carteiraDestino.ReceberBabycoinAnuncio(quantidade);
        }
    }
}


/-------------------CONTROLLER CARTEIRA--------------------------/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;
using Microsoft.AspNetCore.Authorization;

namespace app_babybay.Controllers
{
    [Authorize]
    public class CarteirasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarteirasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carteiras
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Carteiras.Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Deposita10(int Id, int Deposito, Carteira carteira, Usuario usuario)
        {
            var carteiraUser = await _context.Carteiras.FirstOrDefaultAsync(m => m.Id == carteira.Id);
          
                carteiraUser.Receber(10);

                ViewBag.Message = "Depósito realizado com sucesso";
                _context.Update(carteiraUser);
                await _context.SaveChangesAsync();

                return View("CompraConfirmada_10");       
        }
        public async Task<IActionResult> Deposita20(int Id, Carteira carteira, Usuario usuario)
        {
            var carteiraUser = await _context.Carteiras.FirstOrDefaultAsync(m => m.Id == carteira.Id);

            carteiraUser.Receber(20);

            ViewBag.Message = "Depósito realizado com sucesso";
            _context.Update(carteiraUser);
            await _context.SaveChangesAsync();
            return View("CompraConfirmada_20");

        }
        public async Task<IActionResult> Deposita30(int Id, Carteira carteira, Usuario usuario)
        {
            var carteiraUser = await _context.Carteiras.FirstOrDefaultAsync(m => m.Id == carteira.Id);

            carteiraUser.Receber(30);

            ViewBag.Message = "Depósito realizado com sucesso";
            _context.Update(carteiraUser);
            await _context.SaveChangesAsync();
            return View("CompraConfirmada_30");

        }

        // GET: Carteiras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteira = await _context.Carteiras
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteira == null)
            {
                return NotFound();
            }

            return View(carteira);
        }

        // GET: Carteiras/Create
        public IActionResult Create()
        { 
            return View();
        }

        // POST: Carteiras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,Saldo")] Carteira carteira)
        {
            if (ModelState.IsValid)
            {               
                _context.Add(carteira);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carteira);
        }

        // GET: Carteiras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteira = await _context.Carteiras.FindAsync(id);
            if (carteira == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", carteira.UsuarioId);
            return View(carteira);
        }      
       
        // GET: Carteiras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carteira = await _context.Carteiras
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carteira == null)
            {
                return NotFound();
            }

            return View(carteira);
        }

        // POST: Carteiras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carteira = await _context.Carteiras.FindAsync(id);
            _context.Carteiras.Remove(carteira);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarteiraExists(int id)
        {
            return _context.Carteiras.Any(e => e.Id == id);
        }
    }
}


/-------------------CLASSE ANUNCIO--------------------------/


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace app_babybay.Models
{
    [Table("Anuncios")]
    public class Anuncio
    {
        [Key]
        public int AnuncioId { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Selecione o Produto")]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        public int? ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        [MaxLength(20)]
        [Display(Name = "Título do Anúncio")]
        [Required(ErrorMessage = "É necessário informar um título para o anúncio")]
        public string Titulo { get; set; }

		[Display(Name = "Valor em BabyCoin")]
        [Required(ErrorMessage = "É necessário um valor em BabyCoin")]
        public int Babycoin { get; set; }

        public bool InteresseTroca { get; set; }
        [Display(Name = "Usuário interessado:")]
        public string NomeInteressado { get;  private set; }

        [Display(Name = "Roupa proposta para troca:")]
        public int? PropostaAnuncioTroca { get; set; }

        [Display(Name = "A solicitação de troca por BabyCoin:")]
        public bool PropostaAnuncioBabycoin { get; set; }

        [Display(Name = "Roupa proposta para troca:")]
        public string PropostaProdutoTroca { get; set; }

        //public ICollection<Produto> Produtos { get; set; }

        [NotMapped]
        public Dictionary<int, string> listaInteressados { get;  private set; } = new Dictionary<int, string>();
        
        [NotMapped]
        public List<Anuncio> listaAnuncio = new List<Anuncio>();

        [Display(Name = "Data da Solicitação:")]
        private DateTime _date = DateTime.Now;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public bool AnuncioCurtido { get; private set; }

        public int ContadorCurtidas { get; private set; }
        
        
        public Anuncio()//Cria um construtor vazio,que é que sempre é instaciado quando o produto é criado,para sempre iniciar o produto como não curtido
        {
            AnuncioCurtido = false;
        }
        public void AdicionarAnuncioInteressado()
        {
           
                InteresseTroca = true;
      
        }

        public void RemoverAnuncioInteresse()
        {
            InteresseTroca = false;
        }

        public void AdicionarNomeInteressado(string Nome)
        {
            NomeInteressado = Nome;
        }

        public void RemoverNomeInteressado()
        {
            NomeInteressado = "";
        }

        public void AdicionarNomeProduto(string nome)
        {
            PropostaProdutoTroca = nome;
        }



        public void CurtirAnuncio()/*Aqui um método para curtir o produto,sera chamado quando apertar o botão Curtir,static é para ele ser um membro de classe
       para que assim ele estem método possa ser chamado por outro método no controle*/
        {
            AnuncioCurtido = true;
            ContadorCurtidas++;
        }
        public void DescurtirAnuncio()//Aqui um método para descurtir o produto,sera chamado quando apertar o botão curtir denovo,ou quando apertar o botão descurtir(ver depois)
        {
            AnuncioCurtido = false;
            ContadorCurtidas--;    

            if (ContadorCurtidas < 0) // Aqui faz que o contador nunca fique negativo
            {
                ContadorCurtidas = 0;
            }
        }


        public void ZeraContador()//Aqui caso precise,esta um método para zerar contador
        {
            ContadorCurtidas = 0;
        }
    }
}


/-------------------CONTROLLER ANUNCIO--------------------------/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
using Microsoft.AspNetCore.Authentication;

namespace app_babybay.Controllers
{
    [Authorize]
    public class AnunciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnunciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Anuncios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Anuncios.Include(a => a.Produto).Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> MenuAnuncio(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var anuncio = await _context.Anuncios
            //    .FindAsync(id);

            var anuncio = await _context.Anuncios
               .Include(a => a.Produto)
               .Include(a => a.Usuario)
               .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        public async Task<IActionResult> RedirecionarMenuProduto()
        {
            var usuario = await _context.                           
                .FirstOrDefaultAsync(m => m.Nome.Contains(User.Identity.Name));

            return RedirectToAction("Relatorio", "Usuarios", new { id = usuario.Id });
        }

        // GET: Anuncios/Details
        // É chamado depois de clicar em "Eu Quero" na busca
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            // Usuário logado (cliente)
            var usuarioCliente = await _context.Usuarios
               .FirstOrDefaultAsync(p => p.Nome == User.Identity.Name);

            var carteiraCliente = await _context.Carteiras.FirstOrDefaultAsync(a => a.Id == usuarioCliente.Id);

            // LÓGICA FUNCIONA, MAS NÃO EXIBE MSG DO VIEW.MESSAGE NA VIEW
            // NEM NA BUSCCA NEM   
            //if (anuncio.UsuarioId == usuarioCliente.Id)
            //{
            //    ViewBag.Message = "Não é posível escolher um produto que você anunciou";
            //    return RedirectToAction("Index", "Home");
            //}                      
            ViewBag.Message = "* Seu saldo na carteira é de " + carteiraCliente.Saldo + " BabyCoins";
            // Todos anúncios
            var anuncioCliente = from aCliente in _context.Anuncios
                                 select aCliente;
            // Anúncios do Usuário Logado
            anuncioCliente = anuncioCliente.Where(s => s.UsuarioId == usuarioCliente.Id);

            // Passa pro SelectList somente os anúncios do cliente
            ViewData["AnuncioId"] = new SelectList(anuncioCliente, "AnuncioId", "Titulo");

            return View(anuncio);
        }

        // Mostrar informações do pedido.
        // O botão que chama esse método está na tela depois do "Enviar Pedido" 
        // anuncioSelect é o anúncio selecionado pelo cliente para sugerir a troca com o anunciante
        public async Task<IActionResult> EnviarPedido(int? id, [Bind("AnuncioId")] Anuncio anuncioSelect, int opcRadio)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Usuarios.FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);
            var carteira = await _context.Carteiras.FirstOrDefaultAsync(a => a.UsuarioId == user.Id);


            // Usuário anunciante, anúncio e produto anunciado
            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);


            if (opcRadio == 0)//Se escolheu utilizar os babycoins,chama o metodo da carteira para tentar retirar o saldo,se retornar false é porque o produto custa mais que o usuário tem na carteira
            {
                bool temsaldo = carteira.Retirar(anuncio.Babycoin);

                if (!temsaldo)
                {
                    ViewBag.Message = "Você não possui saldo suficiente";
                    return RedirectToAction("Details", new { id });
                }

            }
            if (anuncio == null)
            {
                return NotFound();
            }

            // O new serve para passar o parâmetros para o método SalvarPedido
            // id do anuncio, id do anúncio selecionado pelo cliente (esse é o id dos anúncios do cliente, que ele propôs para troca), opcRadio ( Se é babycoin ou prod por prod), objeto anúncio (do anunciante)
            return RedirectToAction("SalvarPedido", new { id, anuncioSelectPropostaId = anuncioSelect.AnuncioId, opcRadio });
        }

        // Vai salvar as informações do usuário interessado no anuncio do anunciante
        // Vai exibir uma pergunta para se o usuário quer realmente confirmar a solicitação de troca
        public async Task<IActionResult> SalvarPedido(int? id, int? anuncioSelectPropostaId, int opcRadio)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Anunciante
            var anuncio = await _context.Anuncios
              .Include(a => a.Produto)
              .Include(a => a.Usuario)
              .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            // Pegando o usuário logado (Cliente)           
            var usuarioCliente = await _context.Usuarios
                .FirstOrDefaultAsync(p => p.Nome == User.Identity.Name);

            // Chamando métodos e fazendo as atribuições para salvar no DB
            anuncio.AdicionarNomeInteressado(usuarioCliente.Nome);       // Nome do cliente
            anuncio.AdicionarAnuncioInteressado();                  // Indica que há interesse na troca            
            anuncio.ClienteId = usuarioCliente.Id;                  // Pega o usuário cliente          

            // Vai verificar se o interesse é prod por prod ou por babycoin
            if (opcRadio == 1)           // Produto por produto
            {
                anuncio.PropostaAnuncioTroca = anuncioSelectPropostaId;  // ID anúncio proposto pelo cliente

                // Produtos do Usuário Logado
                var produtoCliente = from aCliente in _context.Produtos
                                     select aCliente;                
                produtoCliente = produtoCliente.Where(s => s.UsuarioId == usuarioCliente.Id);
                
                // Anúncios do Usuário Logado
                var anuncioCliente = from aCliente in _context.Anuncios
                                     select aCliente;
                anuncioCliente = anuncioCliente.Where(s => s.UsuarioId == usuarioCliente.Id);

                // Percorre os anúncios do cliente e compara pra ver se é o mesmo da proposta
                var anuncioSelect = new Anuncio();
                foreach (var itemAnuncio in anuncioCliente)
                {                                   
                    if (itemAnuncio.AnuncioId == anuncioSelectPropostaId)
                    {
                        anuncioSelect = itemAnuncio;
                        break;
                    }
                }

                // Percorre os produtos e comparar para ver se o ID do produto bate com o do anúncio achado acima
                foreach(var itemProduto in produtoCliente)
                {                   
                    if(anuncioSelect.ProdutoId == itemProduto.Id)
                    {
                        anuncio.PropostaProdutoTroca = itemProduto.Nome; // Adiciona o nome do produto encontrado 
                        break;
                    }
                }             

                // Atualiza banco
                _context.Update(anuncio);
                await _context.SaveChangesAsync();

                return View(anuncio);
            }
            else    // É "compra" por babycoin
            {
                // anuncio.PropostaAnuncioTroca = null;
                anuncio.PropostaAnuncioBabycoin = true;

                _context.Update(anuncio);
                await _context.SaveChangesAsync();
                return View(anuncio);
                // Caso não seja produto por produto, ou seja, caso opcRadio == 0, então significa que é por babycoin e atualiza o banco apenas com as informações do interessado e seta como true a propriedade PropostaAnuncioBabycoin              
            }
        }

        // Ponto de vista do anunciante. Vai estar dentro de Meus Anúncios lá na opção Minhas Roupas do menu
        // Tem que exibir o nome do cliente, ainda não consegui
        public async Task<IActionResult> VisualizarSolicitacao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Anunciante
            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // Método chamado de quem aceita a troca, no caso, o Anunciante
        public async Task<ActionResult> AceitarTroca(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Produto do anunciannte (logado), que vai aceitar a troca
            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            // Anuncio de quem propôs a troca (prod por prod), seria o cliente
            var anuncioProposta = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == anuncio.PropostaAnuncioTroca);

            if (anuncio == null)
            {
                return NotFound();
            }

            if (anuncio.PropostaAnuncioBabycoin)    // Se true, então é babycoin
            {
                // Usuário anunciante - logado - quem aceita a troca
                var usuarioAnunciante = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);

                // Cateira Anunciante
                var carteiraAnunciante = await _context.Carteiras
                    .Include(a => a.Usuario)
                    .FirstOrDefaultAsync(m => m.UsuarioId == usuarioAnunciante.Id);

                // Usuario Cliente
                var usuarioCliente = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Id == anuncio.ClienteId);

                // Carteira Cliente
                var carteiraCliente = await _context.Carteiras
                    .Include(a => a.Usuario)
                    .FirstOrDefaultAsync(m => m.UsuarioId == usuarioCliente.Id);

                // Transferindo babycoin
                carteiraCliente.Transferir(anuncio.Babycoin, carteiraAnunciante);

                _context.Anuncios.Remove(anuncio);       // Exclui Anúncio(de quem aceita a troca)
                _context.Update(carteiraCliente);        // Atualiza o saldo da carteira do cliente       
                _context.Update(carteiraAnunciante);     // Atualiza o saldo da carteira do anunciante

                await _context.SaveChangesAsync();       // Atualiza Banco

                return View(anuncio);
            }
            else               // Ajustar: QUando não tem produto para trocar, setar radio direto no babycoin
            {
                // PRODUTO POR PRODUTO
                var idAnunciante = anuncio.UsuarioId;
                var idCliente = anuncioProposta.UsuarioId;

                // Ponto de vista do cliente
                anuncio.Produto.UsuarioId = idCliente;  // Seta UsuarioId no prod (cliente x anunciante)
                _context.Update(anuncio);
                _context.Anuncios.Remove(anuncio);       // Exclui Anúncio (de quem aceita a troca)

                // Ponto de vista do anunciante (quem aceita a troca)
                anuncioProposta.Produto.UsuarioId = idAnunciante;
                _context.Update(anuncioProposta);
                _context.Anuncios.Remove(anuncioProposta);  // Exclui Anúncio (de quem solicita a troca)

                await _context.SaveChangesAsync();          // Atualiza Banco

                return View(anuncio);
            }
        }

        // Buscar Anúncios
        [AllowAnonymous]
        public async Task<IActionResult> Busca(int? idadeProduto, string nomeProduto, Categoria? categoria)
        {
            var buscaAnuncio = from m in _context.Anuncios
                               select m;

            // User Logado
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Nome == User.Identity.Name);

            // Se não estiver logado, então retorna tudo
            if (usuario == null)
            {
                if (!String.IsNullOrEmpty(nomeProduto))
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Titulo.Contains(nomeProduto)
                        || s.Produto.Nome.Contains(nomeProduto));

                    if (idadeProduto == null && categoria == null)   // Sem categoria e sem idade
                    {
                        return View(await buscaAnuncio.ToListAsync());      // Retorna só a busca pelo nome
                    }
                    // Se idade igual outras(7) , então pesquisa somente maior que 6
                    if (idadeProduto != null)           // Se tem idade
                    {
                        buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Idade == idadeProduto);

                        if (categoria == null)          // Se tem idade e não tem categoria
                        {
                            return View(await buscaAnuncio.ToListAsync());      // Retorna pelo nome e idade
                        }
                        else                            // Se tem idade e categoria
                        {
                            buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                            return View(await buscaAnuncio.ToListAsync());   // Retorna pelo nome idade e categoria
                        }
                    }
                    else                                // Se não tem idade
                    {
                        if (categoria == null)          // Se não tem idade nem categoria
                        {
                            return View(await buscaAnuncio.ToListAsync());      // Retorna tudo
                        }
                        else                             // Se não tem idade e tem categoria
                        {
                            buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                            return View(await buscaAnuncio.ToListAsync());
                        }
                    }
                }
                else if (idadeProduto != null)           // Se tem idade e não tem produto
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Idade == idadeProduto);

                    if (categoria == null)          // Se tem idade e não tem categoria nem produto
                    {
                        return View(await buscaAnuncio.ToListAsync());
                    }
                    else                            // Se tem idade e categoria e não tem produto
                    {
                        buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                        return View(await buscaAnuncio.ToListAsync());
                    }
                }
                else                                // Se não tem idade nem produto
                {
                    if (categoria == null)          // Se não tem idade nem categoria nem produto
                    {
                        return View(await buscaAnuncio.ToListAsync());      // Retorna tudo
                    }
                    else                             // Se não tem idade nem produto e tem categoria
                    {
                        buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                        return View(await buscaAnuncio.ToListAsync());
                    }
                }

            }

            // Se tiver produto digitado
            if (!String.IsNullOrEmpty(nomeProduto))
            {
                // Se o usuário estiver logado, então não mostrar os anúncios dele
                buscaAnuncio = buscaAnuncio.Where(s => s.Titulo.Contains(nomeProduto)
                    && s.UsuarioId != usuario.Id
                    || s.Produto.Nome.Contains(nomeProduto)
                    && s.UsuarioId != usuario.Id);

                // Original
                //buscaAnuncio = buscaAnuncio.Where(s => s.Titulo.Contains(nomeProduto)                
                //|| s.Produto.Nome.Contains(nomeProduto));

                if (idadeProduto == null && categoria == null)   // Sem categoria e sem idade
                {
                    return View(await buscaAnuncio.ToListAsync());      // Retorna só a busca pelo nome
                }
                // Se idade igual outras(7) , então pesquisa somente maior que 6
                if (idadeProduto != null)           // Se tem idade
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Idade == idadeProduto && s.UsuarioId != usuario.Id);

                    if (categoria == null)          // Se tem idade e não tem categoria
                    {
                        return View(await buscaAnuncio.ToListAsync());      // Retorna pelo nome e idade
                    }
                    else                            // Se tem idade e categoria
                    {
                        buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria && s.UsuarioId != usuario.Id);
                        return View(await buscaAnuncio.ToListAsync());   // Retorna pelo nome idade e categoria
                    }
                }
                else                                // Se não tem idade
                {
                    if (categoria == null)          // Se não tem idade nem categoria
                    {
                        return View(await buscaAnuncio.ToListAsync());      // Retorna tudo
                    }
                    else                             // Se não tem idade e tem categoria
                    {
                        buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria && s.UsuarioId != usuario.Id); return View(await buscaAnuncio.ToListAsync());
                    }
                }
            }
            else if (idadeProduto != null)           // Se tem idade e não tem produto
            {
                buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Idade == idadeProduto && s.UsuarioId != usuario.Id);

                if (categoria == null)          // Se tem idade e não tem categoria nem produto
                {

                    return View(await buscaAnuncio.ToListAsync());
                }
                else                            // Se tem idade e categoria e não tem produto
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria && s.UsuarioId != usuario.Id);
                    return View(await buscaAnuncio.ToListAsync());
                }
            }
            else                                // Se não tem idade nem produto
            {
                if (categoria == null)          // Se não tem idade nem categoria nem produto
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.UsuarioId != usuario.Id);
                    return View(await buscaAnuncio.ToListAsync());      // Retorna tudo
                }
                else                             // Se não tem idade nem produto e tem categoria
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria && s.UsuarioId != usuario.Id);
                    return View(await buscaAnuncio.ToListAsync());
                }
            }
        }


        // GET: Anuncios/Create   
        public async Task<IActionResult> CurtirAnuncio(int id, [Bind("AnuncioCurtido")] Produto produto)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);

            anuncio.CurtirAnuncio();    // Chama método que manda true de retorno
            _context.Update(anuncio);   // Atualiza a tabela anúncio com a informação da 'curtida'
            await _context.SaveChangesAsync();  // Salva

            return RedirectToAction("Details", "Anuncios", new { id });
        }

        public async Task<IActionResult> DescurtirAnuncio(int id, [Bind("AnuncioCurtido")] Produto produto)
        {
            var roupa = await _context.Anuncios.FindAsync(id);//Aqui em teoria pega o valor do produto (id dele)e encontra o produto com aquele id

            roupa.DescurtirAnuncio();//Aqui chama o método que faz com que a váriavel ProdutoCurtido passe para false,indicando que o produto foi removido dos favoritos
            _context.Update(roupa);//Aqui deveria adicionar a objeto roupa,incluindo o ProdutoCurtido,mas da erro.
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnuncioId,ProdutoId,Titulo,Babycoin")] Anuncio anuncio, int id)
        {   // int id pega o id passado no botão 'anunciar' na view Relatorios (controller usuarios)

            if (ModelState.IsValid)
            {
                // Pega o nome do user logado
                // var TUser = User.Identity.Name;
                var usuario = new Usuario();

                // Percorre no BD buscando pelo nome compara com  usuário logado
                usuario = await _context.Usuarios
                     .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);
                anuncio.Usuario = usuario;          // Objeto Usuario encontrado para Usuario no anuncio

                // Verifica se existe o produto na tabela anúncio
                var buscaAnuncio = await _context.Anuncios
                    .FirstOrDefaultAsync(m => m.ProdutoId == id);

                // Se produto já está anunciado, mostra msg na tela
                if (buscaAnuncio != null)
                {
                    ViewBag.Message = "O produto já está anunciado";
                }
                else  // Se o produto não está anunciado, então atribui no anuncio e manda pro BD
                {

                    // Aqui vai setar o ClienteId para null
                    // Quando alguém solicitar a troca, então ele será setado com o Id de quem solicitou, no método SalvarPedido
                    var produto = await _context.Produtos.FindAsync(id);
                    anuncio.Produto = produto;
                    anuncio.ClienteId = null;

                    _context.Add(anuncio);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Relatorio", "Usuarios", new { id = anuncio.UsuarioId });
                }
            }

            // Se entrou no if, vai redirecionar para index
            return View(anuncio);
        }


        // GET: Anuncios/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);

            var anuncio = await _context.Anuncios.FindAsync(id);
            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
            return RedirectToAction("Relatorio", "Usuarios", new { usuario.Id });
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncios.Any(e => e.AnuncioId == id);
        }
    }

}


//// Pegando todos os anuncios
//var anuncioCliente = from aCliente in _context.Anuncios
//                     select aCliente;

//// Pegando somente os anúncios do usuário logado
//anuncioCliente = anuncioCliente.Where(s => s.Usuario.Nome.Contains(User.Identity.Name));

// Select somente dos anúncios do usuário logado
//ViewData["Anuncios"] = new SelectList(anuncioCliente, "AnuncioId", "Titulo");



/-------------------CLASSE SUPORTE--------------------------/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Suportes")]
    public class Suporte
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Solicitação do Usuário")]
        public string ReclamacaoUsuario { get; set; }

        [Display(Name = "Resposta do Suporte")]
        public string TextoSuporte { get; set; }
        public static int Contador { get; set; }//Mais de 10 reclamações,suspendeiria o anuncio em questão

        public DateTime _date = DateTime.Now;

        public int AnuncioId { get; set; }
        [ForeignKey("AnuncioId")]
        public Anuncio Anuncio { get; set; }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public ICollection<Usuario> Usuarios { get; set; }

        public bool RegistrarDenuncia(string reclamação)
        {

            if (string.IsNullOrEmpty(reclamação))
            {
                return false;
            }
            else
            {
                ReclamacaoUsuario = reclamação;

                Contador++;
                return true;
            }

        }
        public void AdicionarIdAnuncio(int id)
        {
            AnuncioId += id;/*No caso irá guarda o id na variável de AnuncioId,pois na tabela suporte ,ela 
                             essa variável não tem muita utilidade com chave estrangeira,então será usada para
                             outra utilizada*/
        }


    }
}


/-------------------CONTROLLER SUPORTE--------------------------/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;

namespace app_babybay.Controllers
{
    public class SuportesController : Controller
    {
        public static int GuardaIdAnuncio;

        private readonly ApplicationDbContext _context;

        public SuportesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suportes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Suportes.Include(s => s.Anuncio).Include(s => s.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Suportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suportes
                .Include(s => s.Anuncio)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suporte == null)
            {
                return NotFound();
            }

            return View(suporte);
        }
        public async Task<IActionResult> confirmaDenuncia(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var denuncia = await _context.Anuncios
                  .Include(a => a.Produto)
                  .Include(a => a.Usuario)
                  .FirstOrDefaultAsync(m => m.AnuncioId == id);
            if (denuncia == null)
            {
                return NotFound();
            }

            return View(denuncia);
        }
        // GET: Suportes/Create
        public  IActionResult Create(int id)
        {
            var anuncio =  _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefault(m => m.AnuncioId == id);

            /*TRATAR - USUÁRIO NÃO PODE QUERER O PRODUTO QUE ELE MESMO ANUNCIOU*//*
            if (anuncio.Usuario.Nome == User.Identity.Name)
            {
                ViewBag.Message = "Não é possível escolher um produto que você anunciou, faça outra busca.";
                return View("~/Views/Anuncios/Busca.cshtml");
            }*/
            GuardaIdAnuncio = id;
            ViewData["AnuncioId"] = new SelectList(_context.Anuncios, "AnuncioId", "Titulo");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro");
            return View();
        }

        // POST: Suportes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarReclamacao([Bind("Id,UsuarioId,ReclamacaoUsuario,TextoSuporte,AnuncioId,Date")] Suporte suporte)
        {
       
            var anuncio = await _context.Anuncios.FirstOrDefaultAsync(m => m.AnuncioId == GuardaIdAnuncio);
            var user = await _context.Usuarios.FirstOrDefaultAsync(a => a.Nome == User.Identity.Name);

            if (ModelState.IsValid)
            {
                suporte.Usuario = user;
              bool Registro =  suporte.RegistrarDenuncia(suporte.ReclamacaoUsuario);
                if (Registro==false)//O metodo irá analisar,caso o usuário tenha digitado algo,se não retorna uma valor falso
                {
                    ViewBag.Message = "Digite alguma coisa na caixa de denúncia";
                    return View("Create");
                }
                suporte.AnuncioId = anuncio.AnuncioId;
               /*Ver porque está registrando a reclamação duplicada*/
               
                _context.Add(suporte);
                await _context.SaveChangesAsync();
                return View("confirmaDenuncia");

            }
            ViewData["AnuncioId"] = new SelectList(_context.Anuncios, "AnuncioId", "Titulo", suporte.AnuncioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", suporte.UsuarioId);
            return View(suporte);
            }

        // GET: Suportes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suportes.FindAsync(id);
            if (suporte == null)
            {
                return NotFound();
            }
            ViewData["AnuncioId"] = new SelectList(_context.Anuncios, "AnuncioId", "Titulo", suporte.AnuncioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", suporte.UsuarioId);
            return View(suporte);
        }

        // POST: Suportes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,ReclamacaoUsuario,TextoSuporte,AnuncioId,Date")] Suporte suporte)
        {
            if (id != suporte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuporteExists(suporte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnuncioId"] = new SelectList(_context.Anuncios, "AnuncioId", "Titulo", suporte.AnuncioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", suporte.UsuarioId);
            return View(suporte);
        }

        // GET: Suportes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suporte = await _context.Suportes
                .Include(s => s.Anuncio)
                .Include(s => s.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (suporte == null)
            {
                return NotFound();
            }

            return View(suporte);
        }

        // POST: Suportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suporte = await _context.Suportes.FindAsync(id);
            _context.Suportes.Remove(suporte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuporteExists(int id)
        {
            return _context.Suportes.Any(e => e.Id == id);
        }
    }
}


/-------------------CLASSE TROCA--------------------------/


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Trocas")]
    public class Troca 
    {       
        [Key]
        public int Id { get; set; }

        public int UsuarioClienteId { get; set; }
        [ForeignKey("UsuarioClienteId")]
        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]       
        public Usuario Usuario { get; set; }      

        [Display(Name = "Título do Anúncio")]   // Vai aparecer na View
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]        
        public Produto Produto { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [NotMapped]
        public int Quantidade { get; private set; }

        public int AnunciooId { get; set; }

        [ForeignKey("AnunciooId")]
        public Anuncio Anuncio { get; set; }

        //public ICollection<Anuncio> Anuncios { get; set; }

        // Método para realizar a troca do produto
        public Produto Receber(Produto produto)
        {         
            if(produto == null)
            {
                return null;
            }
            var produtoRecebido = produto;

            return produtoRecebido;
        }   


        //public void Receber(int quantidade)
        //{
        //    Quantidade += quantidade;
        //}

        //public bool Retirar(int quantidade)
        //{
        //    if (quantidade < 0)
        //    {
        //        return false;
        //    }
        //    Quantidade -= quantidade;
        //    return true;
        //}

        //public void Transferir(int quantidade, Produto produtoDestino)
        //{
        //    if (quantidade < 0)
        //    {
        //        return;
        //    }
        //    Retirar(quantidade);
        //    produtoDestino.Receber(quantidade);
        //}

    }
}


/-------------------CONTROLLER TROCA--------------------------/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;
using Microsoft.AspNetCore.Authorization;

namespace app_babybay.Controllers
{
    [Authorize]
    public class TrocasController : Controller
    {
        private readonly ApplicationDbContext _context;

       // public object Trocas { get; internal set; } // inserido

        public TrocasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trocas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trocas
                .Include(c => c.Produto)
                .Include(a => a.Anuncio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trocas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var troca = await _context.Trocas
                .Include(t => t.Usuario)
                .Include(t => t.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (troca == null)
            {
                return NotFound();
            }

            return View(troca);
        }


        // GET: Trocas/Create
        public IActionResult Create()
        {
            ViewData["AnuncioId"] = new SelectList(_context.Anuncios, "AnuncioId", "Titulo");   // Para Criar o Select no create
            return View();
        }

        // POST: Trocas/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,UsuarioId,Date,UsuarioClienteId,AnunciooId")] Troca troca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(troca);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();  
            }

            //return View(troca);
           //return RedirectToAction("Create");
        }


        // GET: Trocas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var troca = await _context.Trocas.FindAsync(id);
            if (troca == null)
            {
                return NotFound();
            }

            return View(troca);
        }

        // POST: Trocas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,UsuarioId,Date,Saldo")] Troca troca)
        {
            if (id != troca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(troca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrocaExists(troca.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(troca);
        }

        // GET: Trocas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var troca = await _context.Trocas
                .Include(t => t.Usuario)
                .Include(t => t.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (troca == null)
            {
                return NotFound();
            }

            return View(troca);
        }

        // POST: Trocas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var troca = await _context.Trocas.FindAsync(id);
            _context.Trocas.Remove(troca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrocaExists(int id)
        {
            return _context.Trocas.Any(e => e.Id == id);
        }
    }
}


//Anuncio anunciante = new Anuncio();
//var user = _context.Usuarios.FirstOrDefault(s => s.Nome == User.Identity.Name);/*Aqui ele busca o usuário LOGADO pelo seu nome
//e pega seu id para posteriormente adicionar a lista do usuário QUE POSSUI O PRODUTO*/

//anunciante =  _context.Anuncios.FirstOrDefault(s => s.AnuncioId == troca.AnunciooId);/*Aqui faz uma busca e busca pelo 
//id do produto selecionado,e guarda em uma instância do tipo anuncio anunciante,para posteriormente chamar o método que ira adicionar
//na lista do USUARIO QUE TEM O PRODUTO o id do usuário interessado e o nome do produto(talvez possa ao inves de guardar o titulo do anuncio
//Guarda o Id do produto*/
//if (anunciante.UsuarioId == user.Id) /*Aqui compara caso o usuario do anunciate do produto for o mesmo do usuario logado,para não deixar
//    ele solicitar troca para ele mesmo*/
//{
//    ViewBag.Message = "Você não pode escolher um produto que voce mesmo anunciou";

//    return View("Create");
//}

//    ViewBag.Message="Solicitação de troca realizada com sucesso" ;
//    anunciante.AdicionarInteressado(user.Id, anunciante.Titulo);/*Aqui chama o método do anunciante para guardar em sua lista
// o Id do usuário interessado e o produto interessado(NOME OU ID,VER DEPOIS)*/

//    Produto produto = new Produto();
//    _context.Update(anunciante);
//    await _context.SaveChangesAsync();


/-------------------CLASSE APPLICATIONDBCONTEXT--------------------------/


using Microsoft.EntityFrameworkCore;
using app_babybay.Models;

namespace app_babybay.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Troca> Trocas { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Suporte> Suportes { get; set; }
    }
}









