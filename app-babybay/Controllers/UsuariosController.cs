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


