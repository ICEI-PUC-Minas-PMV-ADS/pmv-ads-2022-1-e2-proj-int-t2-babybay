using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name = "Título do Anúncio")]
        public string Titulo { get; set; }

        private DateTime _date = DateTime.Now;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public bool AnuncioCurtido { get; set; }

        public int ContadorCurtidas { get; set; }
        public Anuncio()//Cria um construtor vazio,que é que sempre é instaciado quando o produto é criado,para sempre iniciar o produto como não curtido
        {
            AnuncioCurtido = false;
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
        }
    }
}
