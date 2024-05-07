using System;
using System.Xml.Linq;
using dontnetstarter.Models;
using dontnetstarter.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using dontnetstarter.DataStore;
using Microsoft.AspNetCore.JsonPatch;

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
			if (VillaData.villaList.FirstOrDefault(u => u.name.ToLower() == villaDto.name.ToLower()) != null)
			{
				ModelState.AddModelError("CustomError", "Villa already exsist");
				return BadRequest(ModelState ); 
			}

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

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VillaDTO> deleteVilla(int id)
		{
			var getVilla = VillaData.villaList.FirstOrDefault(u => u.id == id);

			if (getVilla == null)
			{
				return NotFound();
			}

			VillaData.villaList.Remove(getVilla);
			 
			return Ok();
		}

		[HttpPut("{id:int}", Name = "UpdateVilla")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult updateVilla(int id, [FromBody]VillaDTO villa)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			var getVilla = VillaData.villaList.FirstOrDefault(u => u.id == id);

			if (getVilla == null) return NotFound();

			getVilla.name = villa.name;

			return Ok();
		}

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult updatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchVillaDTO)
		{
			if (patchVillaDTO == null || id == 0) return BadRequest();

			var getVilla = VillaData.villaList.FirstOrDefault(u => u.id == id);

			if (getVilla == null) return NotFound();

			patchVillaDTO.ApplyTo(getVilla, ModelState);

			if (!ModelState.IsValid) return BadRequest(ModelState);

			return Ok();
		}
    }
}