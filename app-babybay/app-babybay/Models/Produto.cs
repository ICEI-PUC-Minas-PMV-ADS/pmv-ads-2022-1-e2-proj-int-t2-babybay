using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Produtos")]
    public class Produto
    {
        // GUARDA ROUPAS VAI ENTRAR COMO METODO
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória.")]
        public string Cor { get; set; }

        [Display(Name = "Faixa Etária")]
        [Required(ErrorMessage = "A faixa etéria é obrigatória.")]
        public int Idade { get; set; }

        [Display(Name = "Tempo de Uso")]
        [Required(ErrorMessage = "O tempo de uso é obrigatório.")]
        public int TempoUso { get; set; }

        [Display(Name = "Descrição do Produto")]
        [Required(ErrorMessage = "Favor inserir uma descrição do produto."), MaxLength(120)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tamanho é obrigatório")]
        public int Tamanho { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public Categoria Categoria { get; set; }
               

        //public ICollection<GuardaRoupa> GuardaRoupas{ get; set; }

        //private DateTime DtCadastro { get; set; }
    
    }

    // Coloca rum ENUM com o intervalo de idade, remover a propriedade Faixa Etária

    public enum Categoria
    {
        Camiseta,
        Short,
        Calça,
        Macacão,
        Calçado,
        Outros
    }
}

