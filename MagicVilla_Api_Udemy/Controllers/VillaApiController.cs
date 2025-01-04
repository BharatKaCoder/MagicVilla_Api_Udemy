using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Api_Udemy.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villaapi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> logger;
        private readonly ApplicationDbContext _dbContext;

        public VillaApiController(ILogger<VillaApiController> _logger, ApplicationDbContext DbContext)
        {
            logger = _logger;
            _dbContext = DbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        public ActionResult <IEnumerable<VillaDTO>> GetVillas() 
        {
            logger.LogInformation("Getting All Villas");
            return Ok(_dbContext.VillasTable);

        }

        [HttpGet("int{id}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillasById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var Villas = _dbContext.VillasTable.FirstOrDefault(x => x.Id == id);
            if (Villas == null) 
            { 
                return NotFound();
            }
            return Ok(Villas);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if (_dbContext.VillasTable.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already exist!");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            if (villaDTO.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            VillaModel Model = new()
            {
                 Id = villaDTO.Id,
                 Name =     villaDTO.Name,
                 Description =  villaDTO.Description,
                 Rate = villaDTO.Rate,
                 SqFt = villaDTO.SqFt,
                ImageUrl = villaDTO.ImageUrl,          
                Amenity = villaDTO.Amenity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _dbContext.VillasTable.Add(Model);
            _dbContext.SaveChanges();   
            return CreatedAtRoute("GetVilla", new { id = villaDTO.Id }, villaDTO);
        }
    }
    
}
