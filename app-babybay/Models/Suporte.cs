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



        public bool RegistrarDenuncia(string reclamação)
        {

            if (string.IsNullOrEmpty(reclamação))
            {
                return false;
            }
            else
            {
                ReclamacaoUsuario += reclamação;

                Contador++;
                return true;


            }

        }
        public void AdicionarIdAnuncio(int id)
        {
            AnuncioId += id;/*No caso irá guarda o id na variável de AnuncioId,pois na tabela suporte ,ela 
                             essa variável não tem muita utilidade com chave estrangeira,então será usada para
                             outra utilizada*/
        }


    }
}
