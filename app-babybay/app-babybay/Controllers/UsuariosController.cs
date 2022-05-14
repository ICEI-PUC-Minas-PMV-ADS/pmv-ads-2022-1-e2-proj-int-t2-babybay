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
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Login View
        public IActionResult Login()
        {
            return View();
        }

        // Login Validação
        [HttpPost]
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
                ViewBag.Message = "Usuário Ok";
                return View();
            }

            // A senha estiver incorreta, exibe na tela
            ViewBag.Message = "Usuário ou senha inválidos";

            return View();
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
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
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Cpf,Telefone,Rua,Bairro,Cidade,Estado,Email,Senha,ConfirmarSenha")] Usuario usuario)
        {
            /*Aqui ele ira comparar se a senha e o confirmar senha são iguais,caos sejam ele da proseguimento a criação do usuários
                caso não sejam iguais,ele retorna a mesma pagina,ver depois como colocar mensagem de senha diferentes embaixo do display                                        */
            if (ModelState.IsValid && usuario.Senha == usuario.ConfirmarSenha)
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
            return View(usuario);//Caso ou estado do model esteja inválido ou as senhas estejam diferentes,ele retornara a a view do usuário,a atual no caso
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
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
