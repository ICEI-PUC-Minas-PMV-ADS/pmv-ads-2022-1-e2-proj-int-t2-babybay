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

        // GET: Anuncios/Details
        // É chamado depois de clicar em "Eu Quero" na busca
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

            // Usuário logado (cliente)
            var usuarioCliente = await _context.Usuarios
               .FirstOrDefaultAsync(p => p.Nome == User.Identity.Name);

            // LÓGICA FUNCIONA, MAS NÃO EXIBE MSG DO VIEW.MESSAGE NA VIEW
            // NEM NA BUSCCA NEM   
            if (anuncio.UsuarioId == usuarioCliente.Id)
            {
                ViewBag.Message = "Não é posível escolher um produto que você anunciou";
                return RedirectToAction("Index", "Home");
            }                      

            // Todos anúncios
            var anuncioCliente = from aCliente in _context.Anuncios
                                       select aCliente;
            // Anúncios do Usuário Logado
            anuncioCliente = anuncioCliente.Where(s => s.UsuarioId == usuarioCliente.Id);          
       
            // Passa pro SelectList somente os anúncios do cliente
            ViewData["AnuncioId"] = new SelectList(anuncioCliente, "AnuncioId", "Titulo");

            return View(anuncio);
        }

        // Mostrar informações do pedido.
        // O botão que chama esse método está na tela depois do "Enviar Pedido" 
        // anuncioSelect é o anúncio selecionado pelo cliente para sugerir a troca com o anunciante
        public async Task<IActionResult> EnviarPedido(int? id, [Bind("AnuncioId")] Anuncio anuncioSelect, int opcRadio)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Usuarios.FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);
            var carteira = await _context.Carteiras.FirstOrDefaultAsync(a => a.UsuarioId == user.Id);

            // Usuário anunciante, anúncio e produto anunciado
            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);


            //if (opcRadio == 0)//Se escolheu utilizar os babycoins,chama o metodo da carteira para tentar retirar o saldo,se retornar false é porque o produto custa mais que o usuário tem na carteira
            //{
            //    bool temsaldo = carteira.Retirar(anuncio.Babycoin);

            //    if (!temsaldo)
            //    {
            //        ViewBag.Message = "Você não possui saldo suficiente";
            //        return RedirectToAction("Details", new {id});
            //    }

            //}
            if (anuncio == null)
            {
                return NotFound();
            }

            // O new serve para passar o parâmetros para o método SalvarPedido
            // id do anuncio, id do anúncio selecionado pelo cliente (esse é o id dos anúncios do cliente, que ele propôs para troca), opcRadio ( Se é babycoin ou prod por prod), objeto anúncio (do anunciante)
            return RedirectToAction("SalvarPedido", new { id, anuncioSelectPropostaId = anuncioSelect.AnuncioId, opcRadio });
        }

        // Vai salvar as informações do usuário interessado no anuncio do anunciante
        // Vai exibir uma pergunta para se o usuário quer realmente confirmar a solicitação de troca
        public async Task<IActionResult> SalvarPedido(int? id, int? anuncioSelectPropostaId, int opcRadio)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Anunciante
            var anuncio = await _context.Anuncios
              .Include(a => a.Produto)
              .Include(a => a.Usuario)
              .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            // Pegando o usuário logado (Cliente)           
            var usuarioCliente = await _context.Usuarios
               .FirstOrDefaultAsync(p => p.Nome == User.Identity.Name);

            // Chamando métodos e fazendo as atribuições para salvar no DB
            anuncio.AdicionarNomeInteressado(usuarioCliente.Nome); ;       // Nome do cliente
            anuncio.AdicionarAnuncioInteressado();          // Indica que há interesse na troca
            anuncio.ClienteId = usuarioCliente.Id;          // Pega o usuário cliente          

            // Vai verificar se o interesse é prod por prod ou por babycoin
            if (opcRadio == 1)           // Produto por produto
            {
                anuncio.PropostaAnuncioTroca = anuncioSelectPropostaId;  // ID anúncio proposto pelo cliente

                // Atualiza banco
                _context.Update(anuncio);
                await _context.SaveChangesAsync();

                return View(anuncio);
            }
            else    // É "compra" por babycoin
            {
                // anuncio.PropostaAnuncioTroca = null;
                anuncio.PropostaAnuncioBabycoin = true;

                _context.Update(anuncio);
                await _context.SaveChangesAsync();
                return View(anuncio);
                // Caso não seja produto por produto, ou seja, caso opcRadio == 0, então significa que é por babycoin e atualiza o banco apenas com as informações do interessado e seta como true a propriedade PropostaAnuncioBabycoin              
            }
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
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            if (anuncio == null)
            {
                return NotFound();
            }

            return View(anuncio);
        }

        // Método chamado de quem aceita a troca, no caso, o Anunciante
        public async Task<ActionResult> AceitarTroca(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Produto do anunciannte (logado), que vai aceitar a troca
            var anuncio = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == id);

            // Anuncio de quem propôs a troca (prod por prod), seria o cliente
            var anuncioProposta = await _context.Anuncios
                .Include(a => a.Produto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.AnuncioId == anuncio.PropostaAnuncioTroca);

            if (anuncio == null)
            {
                return NotFound();
            }

            if (anuncio.PropostaAnuncioBabycoin)    // Se true, então é babycoin
            {
                // Usuário anunciante - logado - quem aceita a troca
                var usuarioAnunciante = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Nome == User.Identity.Name);

                // Cateira Anunciante
                var carteiraAnunciante = await _context.Carteiras
                    .Include(a => a.Usuario)
                    .FirstOrDefaultAsync(m => m.UsuarioId == usuarioAnunciante.Id);

                // Usuario Cliente
                var usuarioCliente = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.Id == anuncio.ClienteId);

                // Carteira Cliente
                var carteiraCliente = await _context.Carteiras
                    .Include(a => a.Usuario)
                    .FirstOrDefaultAsync(m => m.UsuarioId == usuarioCliente.Id);

                // Transferindo babycoin
                carteiraCliente.Transferir(anuncio.Babycoin, carteiraAnunciante);

                _context.Anuncios.Remove(anuncio);       // Exclui Anúncio(de quem aceita a troca)
                _context.Update(carteiraCliente);        // Atualiza o saldo da carteira do cliente        
                _context.Update(carteiraAnunciante);     // Atualiza o saldo da carteira do anunciante

                await _context.SaveChangesAsync();       // Atualiza Banco

                return View(anuncio);
            }
            else               // Ajustar: QUando não tem produto para trocar, setar radio direto no babycoin
            {
                // PRODUTO POR PRODUTO
                var idAnunciante = anuncio.UsuarioId;
                var idCliente = anuncioProposta.UsuarioId;

                // Ponto de vista do cliente
                anuncio.Produto.UsuarioId = idCliente;  // Seta UsuarioId no prod (cliente x anunciante)
                _context.Update(anuncio);
                _context.Anuncios.Remove(anuncio);       // Exclui Anúncio (de quem aceita a troca)

                // Ponto de vista do anunciante (quem aceita a troca)
                anuncioProposta.Produto.UsuarioId = idAnunciante;
                _context.Update(anuncioProposta);
                _context.Anuncios.Remove(anuncioProposta);  // Exclui Anúncio (de quem solicita a troca)

                await _context.SaveChangesAsync();          // Atualiza Banco

                return View(anuncio);
            }
        }

        // Buscar Anúncios
        [AllowAnonymous]
        public async Task<IActionResult> Busca(int? idadeProduto, string nomeProduto, Categoria? categoria)
        {
            var buscaAnuncio = from m in _context.Anuncios
                               select m;

            // Se tiver produto digitado
            if (!String.IsNullOrEmpty(nomeProduto))
            {
                buscaAnuncio = buscaAnuncio.Where(s => s.Titulo.Contains(nomeProduto)
                    || s.Produto.Nome.Contains(nomeProduto));

                if (idadeProduto == null && categoria == null)   // Sem categoria e sem idade
                {
                    return View(await buscaAnuncio.ToListAsync());      // Retorna só a busca pelo nome
                }
                // Se idade igual outras(7) , então pesquisa somente maior que 6
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
        public async Task<IActionResult> CurtirAnuncio(int id, [Bind("AnuncioCurtido")] Produto produto)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);

            anuncio.CurtirAnuncio();    // Chama método que manda true de retorno
            _context.Update(anuncio);   // Atualiza a tabela anúncio com a informação da 'curtida'
            await _context.SaveChangesAsync();  // Salva

            return RedirectToAction("Details", "Anuncios", new {id});
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
        public async Task<IActionResult> Create([Bind("AnuncioId,ProdutoId,Titulo,Babycoin")] Anuncio anuncio, int id)
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
                    // Quando alguém solicitar a troca, então ele será setado com o Id de quem solicitou, no método SalvarPedido
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


//// Pegando todos os anuncios
//var anuncioCliente = from aCliente in _context.Anuncios
//                     select aCliente;

//// Pegando somente os anúncios do usuário logado
//anuncioCliente = anuncioCliente.Where(s => s.Usuario.Nome.Contains(User.Identity.Name));

// Select somente dos anúncios do usuário logado
//ViewData["Anuncios"] = new SelectList(anuncioCliente, "AnuncioId", "Titulo");