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

        public DateTime Data()
        {
            DateTime data = DateTime.Now;
            return data;
        }
    }
}
