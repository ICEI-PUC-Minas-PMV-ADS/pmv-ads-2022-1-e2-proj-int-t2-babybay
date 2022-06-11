using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace app_babybay.Models
{
    [Table("Anuncios")]
    public class Anuncio
    {
        [Key]
        public int AnuncioId { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Selecione o Produto")]
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        public int? ClienteId { get; set; }
        [ForeignKey("ClienteId")]


        [Display(Name = "Título do Anúncio")]
        public string Titulo { get; set; }

        public bool InteresseTroca { get; set; }

        public string NomeInteressado { get;  private set; }
        public int? PropostaAnuncioTroca { get; set; }

        [NotMapped]
        public Dictionary<int, string> listaInteressados { get;  private set; } = new Dictionary<int, string>();
        
        [NotMapped]
        public List<Anuncio> listaAnuncio = new List<Anuncio>();

        private DateTime _date = DateTime.Now;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public bool AnuncioCurtido { get; private set; }

        public int ContadorCurtidas { get; private set; }
        
        
        public Anuncio()//Cria um construtor vazio,que é que sempre é instaciado quando o produto é criado,para sempre iniciar o produto como não curtido
        {
            AnuncioCurtido = false;
        }
        public void AdicionarAnuncioInteressado()
        {
           
                InteresseTroca = true;
      
        }

        public void RemoverAnuncioInteresse()
        {
            InteresseTroca = false;
        }

        public void AdicionarNomeInteressado(string Nome)
        {
            NomeInteressado = Nome;
        }

        public void RemoverNomeInteressado()
        {
            NomeInteressado = "";
        }

        

        public void CurtirAnuncio()/*Aqui um método para curtir o produto,sera chamado quando apertar o botão Curtir,static é para ele ser um membro de classe
       para que assim ele estem método possa ser chamado por outro método no controle*/
        {
            AnuncioCurtido = true;
            ContadorCurtidas++;
        }
        public void DescurtirAnuncio()//Aqui um método para descurtir o produto,sera chamado quando apertar o botão curtir denovo,ou quando apertar o botão descurtir(ver depois)
        {
            AnuncioCurtido = false;
            ContadorCurtidas--;    

            if (ContadorCurtidas < 0) // Aqui faz que o contador nunca fique negativo
            {
                ContadorCurtidas = 0;
            }
        }


        public void ZeraContador()//Aqui caso precise,esta um método para zerar contador
        {
            ContadorCurtidas = 0;
        }
    }
}
