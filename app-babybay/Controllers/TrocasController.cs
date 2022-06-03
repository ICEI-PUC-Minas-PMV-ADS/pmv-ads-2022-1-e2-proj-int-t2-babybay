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
            ViewData["AnuncioId"] = new SelectList(_context.Anuncios, "AnuncioId", "Titulo");   // Para Criar o Select no create
            return View();
        }

        // POST: Trocas/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnunciooId,UsuarioId")] Troca troca)
        {
            Anuncio anunciante = new Anuncio();
            var user = _context.Usuarios.FirstOrDefault(s => s.Nome == User.Identity.Name);/*Aqui ele busca o usuário LOGADO pelo seu nome
            e pega seu id para posteriormente adicionar a lista do usuário QUE POSSUI O PRODUTO*/
             
            anunciante =  _context.Anuncios.FirstOrDefault(s => s.AnuncioId == troca.AnunciooId);/*Aqui faz uma busca e busca pelo 
            id do produto selecionado,e guarda em uma instância do tipo anuncio anunciante,para posteriormente chamar o método que ira adicionar
            na lista do USUARIO QUE TEM O PRODUTO o id do usuário interessado e o nome do produto(talvez possa ao inves de guardar o titulo do anuncio
            Guarda o Id do produto*/

            anunciante.AdicionarInteressado(user.Id, anunciante.Titulo);/*Aqui chama o método do anunciante para guardar em sua lista
             o Id do usuário interessado e o produto interessado(NOME OU ID,VER DEPOIS)*/
         
            Produto produto = new Produto();
            _context.Update(anunciante);
            await _context.SaveChangesAsync();


/*
            if (ModelState.IsValid)                
            {                             
                _context.Add(troca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
            /*ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", troca.ProdutoId); */// Para Criar o Select no create
            return RedirectToAction("Create");
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
