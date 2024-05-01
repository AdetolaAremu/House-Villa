using System.ComponentModel.DataAnnotations;
namespace dontnetstarter.Models.DTO
{
	public class VillaDTO
	{
		[Required]
		public int id { get; set; }

		[Required]
		[MaxLength(30)]
		public string name { get; set; }

		public DateTime created_at { get; set; }
	}
}

