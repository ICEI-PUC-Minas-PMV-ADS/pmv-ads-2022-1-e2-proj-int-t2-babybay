using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Trocas")]
    public class Troca
    {
        [Key]
        public int Id { get; set; }

        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }



         


        // FALTA TERMINAR

    }
}
