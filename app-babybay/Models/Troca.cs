using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Trocas")]
    public class Troca 
    {
        //[Key]
        //public new int Id { get; set; } // New oculta a implementação da classe base

        //public int ProdutoId { get; set; }
        //[ForeignKey("ProdutoId")]
        //[Display(Name = "Título do Anúncio")]   // Vai aparecer na View
        //public Produto Produto { get; set; }

        //public new int UsuarioId { get; set; }
        //[ForeignKey("UsuarioId")]
        //public new Usuario Usuario { get; set; }

        //public DateTime Date { get; set; }
        /*  public ICollection<Produto> Produtos { get; set; }*/

        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Título do Anúncio")]   // Vai aparecer na View
        public int ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]        
        public Produto Produto { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [NotMapped]
        public int Quantidade { get; private set; }

        public void Receber(int quantidade)
        {
            Quantidade += quantidade;
        }

        public bool Retirar(int quantidade)
        {
            if (quantidade < 0)
            {
                return false;
            }
            Quantidade -= quantidade;
            return true;
        }

        public void Transferir(int quantidade, Produto produtoDestino)
        {
            if (quantidade < 0)
            {
                return;
            }
            Retirar(quantidade);
            produtoDestino.Receber(quantidade);
        }

    }
}
