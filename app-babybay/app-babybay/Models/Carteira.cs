using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Carteira")]
    public class Carteira
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        public int Saldo { get; private set; }

        public Carteira(int id) // Adicionei construtor passando usuarioId (deve estar errado)
        {
            UsuarioId = id;
        }
 

        public void Entrar(int quantidade)
        {
            Saldo += quantidade;
        }

        public bool Sair(int quantidade)
        {
            if (quantidade < 0)
            {
                return false;
            }
            Saldo -= quantidade;
            return true;
        }        

        public void Transferir(int quantidade, Carteira carteiraDestino)
        {
            if (quantidade < 0)
            {
                return;
            }
            this.Sair(quantidade);
            carteiraDestino.Entrar(quantidade);
        }
    }
}
