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

        // GET: Anuncios/Details/5
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

            return View(anuncio);
        }

        // GET: Anuncios/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
          //  ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro");
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnuncioId,ProdutoId,Titulo")] Anuncio anuncio)
        {
            var TUser = User.Identity.Name; // Pega o nome do user logado
            var usuario = new Usuario();
            usuario = await _context.Usuarios  // Percorre no BD buscando pelo nome compara com  TUser
                 .FirstOrDefaultAsync(m => m.Nome == TUser);
            anuncio.Usuario = usuario; // Seta no Objeto Usuario  encontrado para Usuario no anuncio

          //  var produto = new Produto();
         //   produto.Id = anuncio.ProdutoId;
                       

            //if(usuario.Produtos)

            if (ModelState.IsValid)
            {
                _context.Add(anuncio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", anuncio.ProdutoId);
           // ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", anuncio.UsuarioId);
            return View(anuncio);
        }

        // GET: Anuncios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", anuncio.ProdutoId);
          //  ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", anuncio.UsuarioId);
            return View(anuncio);
        }

        // POST: Anuncios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnuncioId,ProdutoId,Titulo")] Anuncio anuncio)
        {
            if (id != anuncio.AnuncioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anuncio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnuncioExists(anuncio.AnuncioId))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", anuncio.ProdutoId);
           // ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", anuncio.UsuarioId);
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
            var anuncio = await _context.Anuncios.FindAsync(id);
            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncios.Any(e => e.AnuncioId == id);
        }
    }
}
