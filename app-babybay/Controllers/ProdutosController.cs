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

        public async Task<IActionResult> CurtirProduto(int id, [Bind("ProdutoCurtido")] Produto produto)//Aqui chama o o método da classe para curtir o produto
        {
            var roupa = await _context.Produtos.FindAsync(id);//Aqui em teoria pega o valor do produto (id dele)e encontra o produto com aquele id

            roupa.CurtirProduto();//Aqui chama o método que faz com que a váriavel ProdutoCurtido passe para true,indicando que o produto foi favoritado
            _context.Update(roupa);//Aqui deveria adicionar a objeto roupa,incluindo o ProdutoCurtido,mas da erro.
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> DescurtirProduto(int id, [Bind("ProdutoCurtido")] Produto produto)
        {
            var roupa = await _context.Produtos.FindAsync(id);//Aqui em teoria pega o valor do produto (id dele)e encontra o produto com aquele id

            roupa.DescurtirProduto();//Aqui chama o método que faz com que a váriavel ProdutoCurtido passe para false,indicando que o produto foi removido dos favoritos
            _context.Update(roupa);//Aqui deveria adicionar a objeto roupa,incluindo o ProdutoCurtido,mas da erro.
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cor,Idade,TempoUso,Descricao,Tamanho,Categoria")] Produto produto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var TUser = User.Identity.Name; // Pega o nome do user logado

                var usuario = new Usuario();
                usuario = await _context.Usuarios  // Percorre no BD buscando pelo nome compara com  TUser
                     .FirstOrDefaultAsync(m => m.Nome == TUser);
                produto.Usuario = usuario; // Seta no Objeto Usuario  encontrado para Usuario no produto
            }
            else
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
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
                return RedirectToAction(nameof(Index));
            }

            // ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "id", "Nome", produto.UsuarioId);
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
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
