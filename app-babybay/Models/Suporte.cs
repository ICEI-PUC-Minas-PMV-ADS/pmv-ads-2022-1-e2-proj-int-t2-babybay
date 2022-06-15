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
        public string TextoUsuario { get; set; }

        [Display(Name = "Resposta do Suporte")]
        public string TextoSuporte { get; set; }

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

    }
}
