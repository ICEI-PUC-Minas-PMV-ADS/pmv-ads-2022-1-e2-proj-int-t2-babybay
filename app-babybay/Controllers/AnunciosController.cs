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
        public async Task<IActionResult> Busca(int idadeProduto, string nomeProduto, string categoria)
        {
            // Aqui é para exibir todos os produtos, ou seja, quando o usuário so clica em buscar
            //var applicationDbContext = _context.Produtos.Include(a => a.Produto);

            // Compara a o produto digitado e o produto que tem no banco, ambos em maiúsculo (ToUpper)
            var produto = new Produto();
            produto = await _context.Produtos
               .FirstOrDefaultAsync(m => m.Nome.ToUpper() == nomeProduto.ToUpper());

            //if (produto != null) // Acertar exceção
            //{
            //    ViewBag.Message = "Produto não encontrado";
            //}

            // Percorre a categoria (enum). Se o elemento for igual a categoria digitada pelo usuário
            // entra no if da idade, se for diferente para a execução
            var anuncio = new Anuncio();
            foreach (var elemento in Enum.GetNames(typeof(Categoria)))
            {
                if (elemento == categoria) // Se categoria digitada igual a alguam (AQUI SEMPRE SERÁ TRUE)
                {
                    if (produto.Idade == idadeProduto)  // Se a categoria acima for igual, eñtão compara a idade
                    {
                        // Pega o Id do produto que foi comparado na busca e verifica se ele está anunciado
                        // Se estiver anunciado, então atribui no objeto
                        anuncio = await _context.Anuncios
                             .FirstOrDefaultAsync(m => m.ProdutoId == produto.Id);
                        break;
                    }
                }                
            }

            // Salvando uma lista -   VIEW ESTÁ COM PROBLEMA
            List<Anuncio> resultado = new List<Anuncio>();
            resultado.Add(anuncio);
            


            //var categ = categoria; // TESTE CATEGORIA, ESTÁ OK, pegando a string
            // Acertar essa hashtable ou pensar outra forma de fazer
            //Hashtable hashCategoria = new Hashtable();
            //hashCategoria.Add(0, "Camiseta");
            //hashCategoria.Add(1, "Short");
            //hashCategoria.Add(2, "Calça");
            //hashCategoria.Add(3, "Macacão");
            //hashCategoria.Add(4, "Calçado");
            //hashCategoria.Add(5, "Outros");

            ////var anuncio = new Anuncio();
            //for (int i = 0; i < hashCategoria.Count; i++)
            //{
            //    // Sempre da true, pq sempre vai existir uma categoria - tem que corrigir
            //    if (hashCategoria.ContainsValue(categoria))
            //    {
            //        anuncio.ProdutoId = produto.Id;
            //        break;
            //    }
            //}

            // Compara o título digitado com o título maiúsculo ???
            //// ta dando erro no meu
            //var a1 = await _context.Anuncios.FirstOrDefaultAsync(m => m.Titulo == anuncio.Titulo);
            ////_context.Anuncios.Single(m => m.Titulo == anuncio.Titulo);//Aqui faz uma busca UNICA (SINGLE)ao invés de buscar por todos os dados do banco,e guarda na variável
            //string Titulobanco = a1.Titulo.ToUpper();//Aqui passa o valor da string retornada pela busca anterior para MAIUSCULO para compara com o campo digitado no banco


            ////------------Parte de busca pelo idade digitada na input no banco
            //var a2 = _context.Produtos.Single(m => m.Idade == produto.Idade);//Aqui faz um busca(query)no banco,tabela PRODUTOS na idade passada pelo parâmetro,e guarda na variável a2 para manipulação
            //int idadeBanco = a2.Idade;



            //if (tituloMaiusculo == Titulobanco && idade == idadeBanco  /*categorias.Contains(Categoria)*/)/*Aqui faz a comparação de caso do que foi digitado nos input e que esta no banco,OBS:A categoria ainda
            //    precisa encontrar um forma de trabalhar com ela*/
            //{
            //    //Aqui em teoria caso desse true na condição acima,retornaria para a view os itens encontrados

            //}
            //return View(await applicationDbContext.ToListAsync());
            return View(anuncio);
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


