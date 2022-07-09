using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace app_babybay.Models
{
	[Table("Images")]
	public class Image
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public int Length { get; set; }
        [Display(Name="Foto do Produto")]
        public byte[] Picture { get; set; }
        public string ContentType { get; set; }

	}
}
