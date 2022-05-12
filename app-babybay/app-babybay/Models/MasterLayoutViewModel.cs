using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    // Testando layout conjunto com models usuario e produto (para cadastrar o produto a partir do usuario)
    // Sem sucesso
    [NotMapped]
    public class MasterLayoutViewModel
    {
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }
        //public ICollections<Produtos> Produto { get; set; }
    }
}
