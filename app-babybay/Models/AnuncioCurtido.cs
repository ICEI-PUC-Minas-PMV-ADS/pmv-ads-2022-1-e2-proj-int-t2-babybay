using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("AnunciosCurtidos")]
    public class AnuncioCurtido
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

		public string NomeAnuncio { get;  private set; }


        public void AdicionarNome(string nome)
		{
            NomeAnuncio = nome;
		}

	}
}
