using app_babybay.Models;
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
        public async Task<IActionResult> Curtir(int id, AnuncioCurtido anuncioCurtido)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);

                anuncioCurtido.UsuarioId = usuario.Id;
                anuncioCurtido.AnuncioCod = id;

                _context.Add(anuncioCurtido);
                await _context.SaveChangesAsync();
            }

            //ViewBag.Message = User.Identity.Name;
            return RedirectToAction("Details", "Anuncios", new { id });
        }

        // TEm que arrumar um jeito de chamar esse método pra mudar a cor do coração
        public async Task<IActionResult> RetornaCurtida(int id)
        {
            bool temAnuncio;

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);

            var anuncioCurtido = await _context.AnunciosCurtidos
                .FirstOrDefaultAsync(m => m.AnuncioCod == id && m.UsuarioId == usuario.Id);

            if(anuncioCurtido != null)
            {
                temAnuncio = true;
            }        

            return RedirectToAction("Details", "Anuncios", new { id });
        }
    }
}
