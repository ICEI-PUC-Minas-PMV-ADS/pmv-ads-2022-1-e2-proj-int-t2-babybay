using app_babybay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace app_babybay.Controllers
{
    public class AnunciosCurtidos : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnunciosCurtidos(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: AnunciosCurtidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Curtir(int idAnuncio, AnuncioCurtido anuncioCurtido)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);

                anuncioCurtido.UsuarioId = usuario.Id;
                anuncioCurtido.AnuncioCod = idAnuncio;

                _context.Add(anuncioCurtido);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Anuncios", new { idAnuncio });
        }
    }
}
//        // POST: AnunciosCurtidos/Delete/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Delete(int id, IFormCollection collection)
//        {
//            try
//            {
//                return RedirectToAction(nameof(Index));
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
