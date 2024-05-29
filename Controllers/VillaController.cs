using dontnetstarter.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using dontnetstarter.DataStore;
using Microsoft.AspNetCore.JsonPatch;
using dontnetstarter.Models;

namespace dontnetstarter.Controllers
{
	[Route("api/getvillas")]
	[ApiController]
	public class VillaController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

		private readonly ILogger<VillaController> _logger;

		public VillaController(ApplicationDbContext db, ILogger<VillaController> logger)
		{
			_logger = logger;
			_db = db;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public ActionResult<IEnumerable<VillaDTO>> GetVilla()
		{
			_logger.LogInformation("Getting all villas");
			return Ok(_db.villas.ToList());
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDTO> getOneVillaDTO(int id)
		{
			_logger.LogInformation("Getting a villa with id" + id);

			if (id == 0)
			{
				return BadRequest();
			}

			var getVilla = _db.villas.FirstOrDefault(u => u.id == id);

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
			if (_db.villas.FirstOrDefault(u => u.name.ToLower() == villaDto.name.ToLower()) != null)
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

			VillaModel model = new(){
				amenity = villaDto.amenity,
				details = villaDto.details,
				id = villaDto.id,
				imageurl = villaDto.imageurl,
				name =  villaDto.name,
				occupancy = villaDto.occupancy,
				rate = villaDto.rate,
				sqft = villaDto.sqft
			};

			_db.villas.Add(model);
			_db.SaveChanges();

			return Ok(villaDto);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<VillaDTO> deleteVilla(int id)
		{
			var getVilla = _db.villas.FirstOrDefault(u => u.id == id);

			if (getVilla == null)
			{
				return NotFound();
			}

			_db.villas.Remove(getVilla);
			 
			return Ok();
		} 

		[HttpPut("{id:int}", Name = "UpdateVilla")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult updateVilla(int id, [FromBody]VillaDTO villaDto)
		{
			if (id == 0)
			{
				return BadRequest();
			}

			VillaModel model = new(){
				amenity = villaDto.amenity,
				details = villaDto.details,
				id = villaDto.id,
				imageurl = villaDto.imageurl,
				name =  villaDto.name,
				occupancy = villaDto.occupancy,
				rate = villaDto.rate,
				sqft = villaDto.sqft
			};
			_db.villas.Update(model);
			_db.SaveChanges();

			return Ok(new { message = "Villa created successfully" });
		}

		[HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public IActionResult updatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchVillaDTO) //JSON PATCH 
		{
			if (patchVillaDTO == null || id == 0) return BadRequest();

			var villa = _db.villas.FirstOrDefault(u => u.id == id);

			if (villa == null) return NotFound();

			VillaDTO villaDto = new(){
				amenity = villa.amenity,
				details = villa.details,
				id = villa.id,
				imageurl = villa.imageurl,
				name =  villa.name,
				occupancy = villa.occupancy,
				rate = villa.rate,
				sqft = villa.sqft
			};

			patchVillaDTO.ApplyTo(villaDto, ModelState);

			VillaModel model = new(){
				amenity = villaDto.amenity,
				details = villaDto.details,
				id = villaDto.id,
				imageurl = villaDto.imageurl,
				name =  villaDto.name,
				occupancy = villaDto.occupancy,
				rate = villaDto.rate,
				sqft = villaDto.sqft
			};
			
			_db.villas.Update(model);
			_db.SaveChanges();

			if (!ModelState.IsValid) return BadRequest(ModelState);

			return Ok();
		}
    }
}