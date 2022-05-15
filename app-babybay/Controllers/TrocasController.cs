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
    public class TrocasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrocasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trocas
        public IActionResult Index()
        {
           // var applicationDbContext = _context.Trocas.Include(c => c.Produto); // Inserido
            return View();
        }

        // GET: Trocas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var troca = await _context.Trocas
                //.Include(t => t.Usuario)
               // .Include(t => t.Produto)
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
            //if (User.Identity.IsAuthenticated)
            //{
            //    var TUser = User.Identity.Name;

               
            //    var usuario = new Usuario();
            //    usuario = await _context.Usuarios
            //         .FirstOrDefaultAsync(m => m.Nome == TUser);

            //    var produto = new Produto();
            //    produto = await _context.Produtos
            //         .FirstOrDefaultAsync(m => m.Nome == TUser);

            //    produto.Usuario = usuario;

            //    ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");    // Para Criar o Select no create
            //    return View();
            //}
            //else
            //{
            //    return NotFound();
            //}
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");   // Para Criar o Select no create
            return View();
        }

        // POST: Trocas/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,UsuarioId")] Troca troca)
        {
            if (User.Identity.IsAuthenticated)
            {
                var TUser = User.Identity.Name; // Pega o nome do user logado

                var usuario = new Usuario();
                usuario = await _context.Usuarios  // Percorre no BD buscando pelo nome compara com  TUser
                     .FirstOrDefaultAsync(m => m.Nome == TUser);
                troca.UsuarioId = usuario.Id; // Seta no Objeto Usuario  encontrado para Usuario no produto

                //var produto = new Produto();
                //produto = await _context.Produtos  // Percorre no BD buscando pelo nome compara com  TUser
                //     .FirstOrDefaultAsync(m => m.Id == ?);
                //troca.Produto = produto; // Seta no Objeto Usuario  encontrado para Usuario no produto
            }
            else
            {
                return NotFound();
            }

            if (ModelState.IsValid)                
            {         
                _context.Add(troca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", troca.ProdutoId); // Para Criar o Select no create
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

            return View(troca);
        }

        // POST: Trocas/Edit/5
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
