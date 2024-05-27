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

		public double rate { get; set; }

		public int sqft { get; set; }

		public int occupancy { get; set; }

		public string imageurl { get; set; }

		public string amenity { get; set; }
    }
}