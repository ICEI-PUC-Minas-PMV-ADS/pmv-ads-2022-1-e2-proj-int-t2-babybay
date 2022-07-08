using System;
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
        public byte[] Picture { get; set; }
        public string ContentType { get; set; }

	}
}
