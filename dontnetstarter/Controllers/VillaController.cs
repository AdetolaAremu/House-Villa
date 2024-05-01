using System;
using System.Xml.Linq;
using dontnetstarter.Models;
using dontnetstarter.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using dontnetstarter.DataStore;

namespace dontnetstarter.Controllers
{
	[Route("api/getvillas")]
	[ApiController]
	public class VillaController : ControllerBase
	{
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<VillaDTO>> GetVilla()
		{
			return Ok(VillaData.villaList);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> getOneVillaDTO(int id)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var getVilla = VillaData.villaList.FirstOrDefault(u => u.id == id);

			if (getVilla == null)
			{
				return NotFound();
			}

            return Ok(getVilla) ;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> createVilla([FromBody] VillaDTO villaDto)
		{
			if (villaDto.id > 0)
			{
				return StatusCode(StatusCodes.Status400BadRequest);
			}

			if (villaDto == null)
			{
				return BadRequest(villaDto);
			}

			villaDto.id = VillaData.villaList.OrderByDescending(u => u.id).FirstOrDefault().id + 1;

			VillaData.villaList.Add(villaDto);

			return Ok(villaDto);
		}
	}
}