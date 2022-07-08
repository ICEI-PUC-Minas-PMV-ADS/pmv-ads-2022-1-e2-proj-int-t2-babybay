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
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> Create([Bind("Id,Nome,Cor,Idade,TempoUso,Descricao,Tamanho,Categoria")] Image Image, IFormFile Img, [FromServices] ApplicationDbContext _context, Produto produto)
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
                Image.Description = produto.Nome;
                Image.Picture = Img.ToByteArray();
                Image.Length = (int)Img.Length;
                Image.Extension = Img.GetExtension();
                Image.ContentType = Img.ContentType;
                _context.Image.Add(Image);
                _context.SaveChanges();

                produto.ImageId = Image.Id;
                _context.Add(produto);
                await _context.SaveChangesAsync();

                // return RedirectToAction("Index", "Usuarios");
                return RedirectToAction("Relatorio", "Usuarios", new { id = produto.UsuarioId });
            }
            return View(produto);
        }

        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public async Task<FileResult> Render(int idProduto, [FromServices] ApplicationDbContext _context)
        {

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == idProduto);

            var item = _context.Image
                .Where(x => x.Id == produto.ImageId)
                .Select(s => new { s.Picture, s.ContentType })
                .FirstOrDefault();

            if (item != null)
            {
                return File(item.Picture, item.ContentType);
            }

            return null;
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
            var image = await _context.Image
                .FirstOrDefaultAsync(m => m.Id == produto.ImageId);

            _context.Image.Remove(image);
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
