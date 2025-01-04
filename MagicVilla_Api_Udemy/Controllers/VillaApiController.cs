using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
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

    }
}
