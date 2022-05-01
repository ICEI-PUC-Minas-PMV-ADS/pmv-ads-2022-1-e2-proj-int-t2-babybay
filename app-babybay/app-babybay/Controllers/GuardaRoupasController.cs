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
    public class GuardaRoupasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GuardaRoupasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GuardaRoupas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GuardaRoupa.Include(g => g.Produto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GuardaRoupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardaRoupa = await _context.GuardaRoupa
                .Include(g => g.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guardaRoupa == null)
            {
                return NotFound();
            }

            return View(guardaRoupa);
        }

        // GET: GuardaRoupas/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor");
            return View();
        }

        // POST: GuardaRoupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,QtdProduto,ProdutoId")] GuardaRoupa guardaRoupa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(guardaRoupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor", guardaRoupa.ProdutoId);
            return View(guardaRoupa);
        }

        // GET: GuardaRoupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardaRoupa = await _context.GuardaRoupa.FindAsync(id);
            if (guardaRoupa == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor", guardaRoupa.ProdutoId);
            return View(guardaRoupa);
        }

        // POST: GuardaRoupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QtdProduto,ProdutoId")] GuardaRoupa guardaRoupa)
        {
            if (id != guardaRoupa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(guardaRoupa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GuardaRoupaExists(guardaRoupa.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Cor", guardaRoupa.ProdutoId);
            return View(guardaRoupa);
        }

        // GET: GuardaRoupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guardaRoupa = await _context.GuardaRoupa
                .Include(g => g.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (guardaRoupa == null)
            {
                return NotFound();
            }

            return View(guardaRoupa);
        }

        // POST: GuardaRoupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var guardaRoupa = await _context.GuardaRoupa.FindAsync(id);
            _context.GuardaRoupa.Remove(guardaRoupa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GuardaRoupaExists(int id)
        {
            return _context.GuardaRoupa.Any(e => e.Id == id);
        }
    }
}
