﻿using System;
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

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

		public Guid ImageId { get; set; }
		[ForeignKey("ImageId")]
        public Image Image { get; set; }

		[Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A cor é obrigatória.")]
        public string Cor { get; set; }

        [Display(Name = "Idade da Criança")]
        [Required(ErrorMessage = "A idade é obrigatória.")]
        public int Idade { get; set; }

        [Display(Name = "Tempo de Uso em Meses")]
        [Required(ErrorMessage = "O tempo de uso é obrigatório.")]
        public int TempoUso { get; set; }

        [Display(Name = "Descrição do Produto")]
        [Required(ErrorMessage = "Favor inserir uma descrição do produto."), MaxLength(120)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O tamanho é obrigatório")]
        public int Tamanho { get; set; }
                
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public Categoria Categoria { get; set; }

        public bool ProdutoCurtido { get; set; }
       /* public bool InteresseTroca { get; set; }

        Dictionary<int, string> listaInteressados = new Dictionary<int, string>();*/

        internal void Receber(int quantidade)
        {
            throw new NotImplementedException();
        }

        // Construtor que inicia o ProdutoCurtido com false
        public Produto()
        {
            ProdutoCurtido = false;                          
        }       

        public void CurtirProduto()/*Aqui um método para curtir o produto,sera chamado quando apertar o botão Curtir,static é para ele ser um membro de classe
       para que assim ele estem método possa ser chamado por outro método no controle*/
        {
            ProdutoCurtido = true;         
        }
        public void DescurtirProduto()//Aqui um método para descurtir o produto,sera chamado quando apertar o botão curtir denovo,ou quando apertar o botão descurtir(ver depois)
        {
            ProdutoCurtido = false;
        }    
         
        
    }

    public enum Categoria
    {         
        Camiseta,
        Short,
        Calça,
        Macacão,
        Calçado,
        Outros
    }

    //public enum Idade
    //{
    //    Zero = 0,
    //    Um = 1,
    //    Dois = 2, 
    //    Três = 3,
    //    Quatro = 4,
    //    Cinco = 5,
    //    Seis = 6,
    //    Outras = 7
    //}
}

