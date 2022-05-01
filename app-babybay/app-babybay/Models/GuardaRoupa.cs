using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("GuardaRoupas")]
    public class GuardaRoupa
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Quantidade")]
        public int QtdProduto { get; set; }

        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

       
        /*public bool ProdutoFavorito { get; set; }*/ //Ver depois como relacionar o produto favoritado a esta variável
    }    
}
