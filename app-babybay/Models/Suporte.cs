using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
    [Table("Suportes")]
    public class Suporte
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Solicitação do Usuário")]
        public string ReclamacaoUsuario { get; set; }

        [Display(Name = "Resposta do Suporte")]
        public string TextoSuporte { get; set; }
        public static int Contador { get; set; }//Mais de 10 reclamações,suspendeiria o anuncio em questão

        public DateTime _date = DateTime.Now;

        public int AnuncioId { get; set; }
        [ForeignKey("AnuncioId")]
        public Anuncio Anuncio { get; set; }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public ICollection<Usuario> Usuarios { get; set; }



        public string RegistrarDenuncia(string reclamação)
        {

            if (string.IsNullOrEmpty(reclamação))
            {
                return "Digite alguma coisa na caixa de texto";
            }
            else
            {
                ReclamacaoUsuario += reclamação;
                Contador++;
                return "Denuncia Registrada com sucesso,nosso time irá analisa-lá";
            }

        }


    }
}
