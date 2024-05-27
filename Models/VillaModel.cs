using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dontnetstarter.Models
{
	public class VillaModel
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int id { get; set; }
		public string name { get; set; }
		public string details { get; set; }
		public double rate { get; set; } 
		public int sqft { get; set; }
		public int occupancy { get; set; }
		public string imageurl { get; set; }
		public string amenity { get; set; }
		public DateTime created_at { get; set; }
		public DateTime updated_at { get; set; }
    }
}

