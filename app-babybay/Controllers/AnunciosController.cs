using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using app_babybay.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections;

namespace app_babybay.Controllers
{
    [Authorize]
    public class AnunciosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnunciosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Anuncios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Anuncios.Include(a => a.Produto).Include(a => a.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Anuncios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // Buscar Anúncios
        [AllowAnonymous]
        public async Task<IActionResult> Busca(int? idadeProduto, string nomeProduto, string categoria)
        {
            // A busca pelo nome está funcionando, porém, tem que dar um jeito de dar um "refresh" na página, pois quando vai buscar pela segunda vez na mesma página, a string nomeProduto vem com valor null e a busca pega todos os produtos, já que a variável não tem valor
            var buscaAnuncio = from m in _context.Anuncios.Include(p => p.Produto)
                               select m;
            
            // Busca por nome do produto ou nome do anúncio OK
            if (!String.IsNullOrEmpty(nomeProduto))
            {
                buscaAnuncio = buscaAnuncio.Where(s => s.Titulo.Contains(nomeProduto)
                                 || s.Produto.Nome.Contains(nomeProduto));
            }

            //var buscaProduto = from c in _context.Produtos
            //                   select c;

            // Testando idade
            // Está filtrando
            //if (idadeProduto != null)
            //{
            //    buscaProduto = buscaProduto.Where(s => s.Idade == idadeProduto);
            //}

            // Concatenar, está com erro: Estudar o funcionamento desses métodos
            //IQueryable<object> query =
            //   buscaAnuncio.AsQueryable()
            //   .Select(c => c.Titulo)
            //   .Concat(buscaProduto.Select(d => d.Nome));


            // TESTANDO CATEGORIA, AINDA NÃO FUNCIONANDO
            //if (!String.IsNullOrEmpty(categoria))
            //{
            //    foreach (var elemento in Enum.GetNames(typeof(Categoria)))
            //    {
            //        if (elemento == categoria)  // Achar a categoria que o usuário selecionou
            //        {

            //        } 
            //    }
            //       // buscaProduto = buscaProduto.Where(s => s.Categoria.CompareTo() == categoria);                
            //}

            return View(await buscaAnuncio.ToListAsync());
        }


        // GET: Anuncios/Create   
        public async Task<IActionResult> CurtirAnuncio(int id, [Bind("AnuncioCurtido")] Produto produto)//Aqui chama o o método da classe para curtir o produto
        {
            var roupa = await _context.Anuncios.FindAsync(id);//Aqui em teoria pega o valor do produto (id dele)e encontra o produto com aquele id

            roupa.CurtirAnuncio();//Aqui chama o método que faz com que a váriavel ProdutoCurtido passe para true,indicando que o produto foi favoritado
            _context.Update(roupa);//Aqui deveria adicionar a objeto roupa,incluindo o ProdutoCurtido,mas da erro.
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DescurtirAnuncio(int id, [Bind("AnuncioCurtido")] Produto produto)
        {
            var roupa = await _context.Anuncios.FindAsync(id);//Aqui em teoria pega o valor do produto (id dele)e encontra o produto com aquele id

            roupa.DescurtirAnuncio();//Aqui chama o método que faz com que a váriavel ProdutoCurtido passe para false,indicando que o produto foi removido dos favoritos
            _context.Update(roupa);//Aqui deveria adicionar a objeto roupa,incluindo o ProdutoCurtido,mas da erro.
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: Anuncios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnuncioId,ProdutoId,Titulo")] Anuncio anuncio, int id)
        {   // int id pega o id passado no botão 'anunciar' na view Relatorios (controller usuarios)

            if (ModelState.IsValid)
            {
                // Pega o nome do user logado
                var TUser = User.Identity.Name;
                var usuario = new Usuario();

                // Percorre no BD buscando pelo nome compara com  TUser
                usuario = await _context.Usuarios
                     .FirstOrDefaultAsync(m => m.Nome == TUser);
                anuncio.Usuario = usuario;          // Objeto Usuario encontrado para Usuario no anuncio

                // Verifica se existe o produto na tabela anúncio
                var buscaAnuncio = await _context.Anuncios
                    .FirstOrDefaultAsync(m => m.ProdutoId == id);

                // Se produto já está anunciado, mostra msg na tela
                if (buscaAnuncio != null)
                {
                    ViewBag.Message = "O produto já está anunciado";
                }
                else  // Se o produto não está anunciado, então atribui no anuncio e manda pro BD
                {
                    // ViewBag.Erro = "O Produto não esta anunciado"; 
                    var produto = await _context.Produtos.FindAsync(id);
                    anuncio.Produto = produto;

                    _context.Add(anuncio);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            // Se entrou no if, vai redirecionar para index
            return View(anuncio);
        }

        //// GET: Anuncios/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var anuncio = await _context.Anuncios.FindAsync(id);
        //    if (anuncio == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", anuncio.ProdutoId);       
        //    return View(anuncio);
        //}

        //// POST: Anuncios/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]            // SER DER TEMPO, ACERTAR
        //public async Task<IActionResult> Edit(int id, [Bind("AnuncioId,ProdutoId,Titulo")] Anuncio anuncio)
        //{
        //    if (id != anuncio.AnuncioId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Pega o nome do user logado
        //            var TUser = User.Identity.Name;
        //            var usuario = new Usuario();

        //            // Percorre no BD buscando pelo nome compara com  TUser
        //            usuario = await _context.Usuarios
        //                 .FirstOrDefaultAsync(m => m.Nome == TUser);
        //            anuncio.Usuario = usuario;          // Objeto Usuario encontrado para Usuario no anuncio

        //            // TERMINAR DE ACERTAR O EDIT

        //            //// Verifica se existe o produto na tabela anúncio
        //            //var produto = new Produto();
        //            //produto = await _context.Anuncios
        //            //     .FirstOrDefaultAsync(m => m.Id == anuncio.ProdutoId);
        //            //anuncio.Usuario = usuario;       

        //            //var teste = anuncio.ProdutoId;


        //            _context.Update(anuncio);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AnuncioExists(anuncio.AnuncioId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome", anuncio.ProdutoId);
        //    return View(anuncio);
        //}

        // GET: Anuncios/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);
            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // POST: Anuncios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            _context.Anuncios.Remove(anuncio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncios.Any(e => e.AnuncioId == id);
        }
    }
}


