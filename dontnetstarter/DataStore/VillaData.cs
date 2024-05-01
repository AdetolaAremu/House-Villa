using System;
using dontnetstarter.Models.DTO;

namespace dontnetstarter.DataStore
{
	public class VillaData
	{
		public static List<VillaDTO> villaList = new List<VillaDTO> {
			new VillaDTO {id = 1, name = "Landmark beach"},
			new VillaDTO { id = 2, name = "Corisi beach and resort" }
		};
	}
}