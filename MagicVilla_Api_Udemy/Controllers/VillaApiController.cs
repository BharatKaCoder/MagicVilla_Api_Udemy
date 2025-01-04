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
        public async Task<ActionResult <IEnumerable<VillaDTO>>> GetVillas() 
        {
            logger.LogInformation("Getting All Villas");
            return Ok(await _dbContext.VillasTable.ToListAsync());

        }

        [HttpGet("int{id}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillasById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var Villas = await _dbContext.VillasTable.FirstOrDefaultAsync(x => x.Id == id);
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

        public async Task <ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO villaDTO)
        {
            var villsList = await _dbContext.VillasTable.FirstOrDefaultAsync(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null;
            if (villsList)
            {
                ModelState.AddModelError("CustomError", "Villa already exist!");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }
            //if (villaDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}

            VillaModel Model = new()
            {
                 Name =     villaDTO.Name,
                 Description =  villaDTO.Description,
                 Rate = villaDTO.Rate,
                 SqFt = villaDTO.SqFt,
                ImageUrl = villaDTO.ImageUrl,          
                Amenity = villaDTO.Amenity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            await _dbContext.VillasTable.AddAsync(Model);
            await _dbContext.SaveChangesAsync();   
            return CreatedAtRoute("GetVilla", new { id = Model.Id }, Model);
        }
    }
    
}
