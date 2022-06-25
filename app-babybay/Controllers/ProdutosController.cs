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

                return RedirectToAction("Index", "Usuarios");
                //return RedirectToAction("Relatorio", "Usuarios", new { produto.UsuarioId });
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
