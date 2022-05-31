﻿using System;
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

        public async Task<IActionResult> Depositar(int Id, int Deposito, Carteira carteira, Usuario usuario)
        {
            var carteiraUser = await _context.Carteiras.FirstOrDefaultAsync(m => m.Id == carteira.Id);
          
                carteiraUser.Receber(Deposito);

                ViewBag.Message = "Depósito realizado com sucesso";
                _context.Update(carteiraUser);
                await _context.SaveChangesAsync();
            
            return View("Details");
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
