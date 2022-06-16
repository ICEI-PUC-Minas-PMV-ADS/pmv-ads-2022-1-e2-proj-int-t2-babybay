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

        // GET: Suportes/Create
        public IActionResult Create()
        {
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
            if (ModelState.IsValid)
            {
                _context.Add(suporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
