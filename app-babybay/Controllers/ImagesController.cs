using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;

namespace app_babybay.Controllers
{
    public class ImagesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ImagesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index([FromServices] ApplicationDbContext _db)
        {
            return View(_db.Image.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Image Image, IFormFile Img, [FromServices] ApplicationDbContext db)
        {
            Image.Picture = Img.ToByteArray();
            Image.Length = (int)Img.Length;
            Image.Extension = Img.GetExtension();
            Image.ContentType = Img.ContentType;
            db.Image.Add(Image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public FileResult Render(string id, [FromServices] ApplicationDbContext db)
        {
            Guid _id = Guid.Parse(id);

            var item = db.Image
                .Where(x => x.Id == _id)
                .Select(s => new { s.Picture, s.ContentType })
                .FirstOrDefault();

            if (item != null)
            {
                return File(item.Picture, item.ContentType);
            }

            return null;
        }

        // GET: Images/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _db.Image
                .FirstOrDefaultAsync(m => m.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Images/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var image = await _db.Image.FindAsync(id);
            _db.Image.Remove(image);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImageExists(Guid id)
        {
            return _db.Image.Any(e => e.Id == id);
        }
    }
}

