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
    public class TrocasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrocasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trocas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trocas.Include(t => t.Usuario).Include(t => t.Produto);
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor");
            return View();
        }

        // POST: Trocas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,UsuarioId,Date,Saldo")] Troca troca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(troca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", troca.UsuarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor", troca.ProdutoId);
            return View(troca);
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", troca.UsuarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor", troca.ProdutoId);
            return View(troca);
        }

        // POST: Trocas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Bairro", troca.UsuarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor", troca.ProdutoId);
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
