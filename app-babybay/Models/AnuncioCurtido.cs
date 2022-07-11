using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("AnunciosCurtidos")]
    public class AnuncioCurtido
    {
        [Key]
        public int Id { get; set; }

        public int AnuncioCod { get; set; }
        [ForeignKey("AnuncioCod")]
        public Anuncio Anuncio { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

    }
}
