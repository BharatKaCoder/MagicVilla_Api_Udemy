using AutoMapper;
using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
using MagicVilla_Api_Udemy.Repository.IRepository;
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
        private readonly IVillaRepository _villaRepository;
        private readonly IMapper _mapper;

        public VillaApiController(ILogger<VillaApiController> _logger, IVillaRepository villaRepository, IMapper mapper)
        {
            logger = _logger;
            //_dbContext = DbContext;

            _villaRepository = villaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        public async Task<ActionResult <IEnumerable<VillaDTO>>> GetVillas() 
        {
            logger.LogInformation("Getting All Villas");
            //IEnumerable<VillaModel> VillaList = await _dbContext.VillasTable.ToListAsync();
            IEnumerable<VillaModel> VillaList = await _villaRepository.GetAllAsync();
            return Ok(_mapper.Map<List<VillaDTO>>(VillaList));

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
            //var Villas = await _dbContext.VillasTable.FirstOrDefaultAsync(x => x.Id == id);
            var Villas = await _villaRepository.GetAsync(x => x.Id == id);
            if (Villas == null) 
            { 
                return NotFound();
            }
            return Ok(_mapper.Map<List<VillaDTO>>(Villas));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task <ActionResult<VillaDTO>> CreateVilla([FromBody] VillaCreateDTO _createvillaDTO)
        {
            var villsList = await _dbContext.VillasTable.FirstOrDefaultAsync(u => u.Name.ToLower() == _createvillaDTO.Name.ToLower()) != null;
            if (villsList)
            {
                ModelState.AddModelError("CustomError", "Villa already exist!");
                return BadRequest(ModelState);
            }
            if (_createvillaDTO == null)
            {
                return BadRequest(_createvillaDTO);
            }
            //if (villaDTO.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            VillaModel Model = _mapper.Map<VillaModel>(_createvillaDTO);
            //VillaModel Model = new()
            //{
            //     Name = _createvillaDTO.Name,
            //     Description = _createvillaDTO.Description,
            //     Rate = _createvillaDTO.Rate,
            //     SqFt = _createvillaDTO.SqFt,
            //    ImageUrl = _createvillaDTO.ImageUrl,          
            //    Amenity = _createvillaDTO.Amenity,
            //    CreatedAt = DateTime.Now,
            //    UpdatedAt = DateTime.Now
            //};
            await _dbContext.VillasTable.AddAsync(Model);
            await _dbContext.SaveChangesAsync();   
            return CreatedAtRoute("GetVilla", new { id = Model.Id }, Model);
        }
    }
    
}
