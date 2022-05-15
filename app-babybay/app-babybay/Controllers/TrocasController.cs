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
            //var applicationDbContext = _context.Trocas.Include(t => t.Usuario).Include(t => t.Produto);
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
            return View();
        }

        // POST: Trocas/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,UsuarioId")] Troca troca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(troca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(troca);
        }

        //// POST: Trocas/Create 
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id")] Troca trocaid)
        //{

        //    var produtoTroca = await _context.Produtos;//Aqui quando for apertar o botão trocar irar percorrer para a tabela produtos procurando o id digitado ou escolhido atraves de um select
        //        .FirstOrDefaultAsync(m => m.Id == trocaid.Id);


        //    if (produtoTroca==null )//Se for nulo,ou seja não possuir aquele produto no bd,retornara um mensagem de erro
        //    {
        //        ViewBag.Message = "Id do produto não encontrado no banco de dados";

        //    }
        //    /*Daqui para baixo é tentar arranhar uma solução "mover"o id do produto do usuario que esta logado,para  outro usuario e passar o id do produto para ESTE usuario*/
        //    trocaid.UsuarioId = produtoTroca.UsuarioId;

         
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(troca);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(troca);
        //}







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
