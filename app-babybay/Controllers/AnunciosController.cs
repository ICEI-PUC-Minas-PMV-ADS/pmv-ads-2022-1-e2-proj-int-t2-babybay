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
using Microsoft.AspNetCore.Authentication;

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

            // Aqui precisa pegar somente os anuncios do ususario logado
            ViewData["AnuncioId"] = new SelectList(_context.Anuncios, "AnuncioId", "Titulo");

            return View(anuncio);
        }

        // Mostrar informações do pedido.
        // O botão que chama esse método está na tela depois do "eu quero" na busca
        public async Task<IActionResult> EnviarPedido(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)    // Produto Anunciado
                .Include(a => a.Usuario)    // Usuario Anunciante
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }


            return View(anuncio);
        }         

        // Vai salvar as informações do usuário interessado no anuncio do anunciante
        // Vai exibir uma pergunta para se o usuário quer realmente confirmar a solicitação de troca
        public async Task<IActionResult> ConfirmarSolicitacao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)    // Produto Anunciado
                .Include(a => a.Usuario)    // Usuario Anunciante
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            // Pegando o usuário logado (Cliente)
            Usuario usuarioCliente = new Usuario();
            usuarioCliente = await _context.Usuarios
               .FirstOrDefaultAsync(p => p.Nome == User.Identity.Name);

            if (anuncio == null)
            {
                return NotFound();
            }
            anuncio.AdicionarNomeInteressado(User.Identity.Name);//Adiciona o nome do cliente no Nome do clietne interessado na tabela anuncio]
            anuncio.AdicionarAnuncioInteressado();   // Indica que há interesse na troca
            anuncio.ClienteId = usuarioCliente.Id; // Pega o usuário cliente (interessado)
            
            _context.Update(anuncio);               // Atualiza
            await _context.SaveChangesAsync();

            return View(anuncio);
        }

        // Ponto de vista do anunciante. Vai estar dentro de Meus Anúncios lá na opção Minhas Roupas do menu
        // Tem que exibir o nome do cliente, ainda não consegui
        public async Task<IActionResult> VisualizarSolicitacao(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Anunciante
            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)    // Produto Anunciado
                .Include(a => a.Usuario)    // Usuario Anunciante
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            // Buscando o cliente
            var buscaCliente = from cliente in _context.Usuarios
                               select cliente;

            buscaCliente = buscaCliente.Where(s => s.Id == anuncio.ClienteId);

            return View(anuncio);
        }


        public async Task<ActionResult> AceitarTroca(int? id) // id do anuncio (de quem anunciou)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)         // Usuário anunciante
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            // Pegando o usuário logado (Cliente)
            Usuario usuarioCliente = new Usuario();
            usuarioCliente = await _context.Usuarios
               .FirstOrDefaultAsync(p => p.Nome == User.Identity.Name);

            if (anuncio == null)
            {
                return NotFound();
            }

            // CLIENTE: Chama o método em troca - OK
            var troca = new Troca();
            var produtoRecebido = troca.Receber(anuncio.Produto);    // Retorna o produto
            produtoRecebido.Usuario = usuarioCliente;                // Seta o usuário cliente no produto recebido
                                                                               
            _context.Update(produtoRecebido);   // Atualiza no banco - Cliente
            await _context.SaveChangesAsync();
                      
            _context.Anuncios.Remove(anuncio);  // Excluindo Anúncio - Anunciante
            await _context.SaveChangesAsync();           

            // (RedirectToAction("DeleteTroca"));         
            return View(anuncio);
        }

        // Buscar Anúncios
        [AllowAnonymous]
        public async Task<IActionResult> Busca(int? idadeProduto, string nomeProduto, Categoria? categoria)
        {
            var buscaAnuncio = from m in _context.Anuncios
                               select m;

            // FUNCIONA, precisa de ajustes quando busca por nome do produto, porque ele não dá um refresh e o resultado fica comprometido
            // A busca por idade e categoria acontece o refresh
            // A lógica funciona corretamente - Realizar mais testes
            // Revisar a lógica para deixar mais sucinta

            // Se tiver produto digitado
            if (!String.IsNullOrEmpty(nomeProduto))
            {
                buscaAnuncio = buscaAnuncio.Where(s => s.Titulo.Contains(nomeProduto)
                    || s.Produto.Nome.Contains(nomeProduto));

                if (idadeProduto == null && categoria == null)   // Sem categoria e sem idade
                {
                    return View(await buscaAnuncio.ToListAsync());      // Retorna só a busca pelo nome
                }

                if (idadeProduto != null)           // Se tem idade
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Idade == idadeProduto);

                    if (categoria == null)          // Se tem idade e não tem categoria
                    {
                        return View(await buscaAnuncio.ToListAsync());      // Retorna pelo nome e idade
                    }
                    else                            // Se tem idade e categoria
                    {
                        buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                        return View(await buscaAnuncio.ToListAsync());   // Retorna pelo nome idade e categoria
                    }
                }
                else                                // Se não tem idade
                {
                    if (categoria == null)          // Se não tem idade nem categoria
                    {
                        return View(await buscaAnuncio.ToListAsync());      // Retorna tudo
                    }
                    else                             // Se não tem idade e tem categoria
                    {
                        buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                        return View(await buscaAnuncio.ToListAsync());
                    }
                }
            }
            else if (idadeProduto != null)           // Se tem idade e não tem produto
            {
                buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Idade == idadeProduto);

                if (categoria == null)          // Se tem idade e não tem categoria nem produto
                {
                    return View(await buscaAnuncio.ToListAsync());
                }
                else                            // Se tem idade e categoria e não tem produto
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                    return View(await buscaAnuncio.ToListAsync());
                }
            }
            else                                // Se não tem idade nem produto
            {
                if (categoria == null)          // Se não tem idade nem categoria nem produto
                {
                    return View(await buscaAnuncio.ToListAsync());      // Retorna tudo
                }
                else                             // Se não tem idade nem produto e tem categoria
                {
                    buscaAnuncio = buscaAnuncio.Where(s => s.Produto.Categoria == categoria);
                    return View(await buscaAnuncio.ToListAsync());
                }
            }           
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
               // var TUser = User.Identity.Name;
                var usuario = new Usuario();

                // Percorre no BD buscando pelo nome compara com  usuário logado
                usuario = await _context.Usuarios
                     .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);
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
                   
                    // Aqui vai setar o ClienteId para null
                    // Quando alguém solicitar a troca, então ele será setado com o Id de quem solicitou, no método ConfirmarSolicitacao
                    var produto = await _context.Produtos.FindAsync(id);
                    anuncio.Produto = produto;
                    anuncio.ClienteId = null;

                    _context.Add(anuncio);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            // Se entrou no if, vai redirecionar para index
            return View(anuncio);
        }


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


