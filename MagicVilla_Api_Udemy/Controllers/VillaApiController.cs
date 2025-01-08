using AutoMapper;
using MagicVilla_Api_Udemy.Models;
using MagicVilla_Api_Udemy.Models.DTO;
using MagicVilla_Api_Udemy.Repository;
using MagicVilla_Api_Udemy.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
        private readonly APIResponse _apiResponse;

        public VillaApiController(ILogger<VillaApiController> _logger, IVillaRepository villaRepository, IMapper mapper)
        {
            logger = _logger;
            //_dbContext = DbContext;

            _villaRepository = villaRepository;
            _mapper = mapper;
            _apiResponse = new();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        public async Task<ActionResult <APIResponse>> GetVillas() 
        {
            try
            {
                logger.LogInformation("Getting All Villas");
                //IEnumerable<VillaModel> VillaList = await _dbContext.VillasTable.ToListAsync();
                IEnumerable<VillaModel> VillaList = await _villaRepository.GetAllAsync();
                _apiResponse.Result = _mapper.Map<List<VillaDTO>>(VillaList);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex) 
            { 
                _apiResponse.Success = false;
                _apiResponse.ErrorMessage = new List<string>() { ex.Message };
            }
            return _apiResponse;
        }

        [HttpGet("int{id}", Name ="GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillasById(int id)
        {
            try
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
                _apiResponse.Result = _mapper.Map<VillaDTO>(Villas);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);

            }
            catch (Exception ex)
            {
                _apiResponse.Success = false;
                _apiResponse.ErrorMessage = new List<string>() { ex.Message };
            }
            return _apiResponse;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task <ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO _createvillaDTO)
        {
            try
            {
            var villsList = await _villaRepository.GetAsync(u => u.Name.ToLower() == _createvillaDTO.Name.ToLower()) != null;
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
            VillaModel villa = _mapper.Map<VillaModel>(_createvillaDTO);
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
            await _villaRepository.CreateAsync(villa);
            _apiResponse.Result = _mapper.Map<VillaDTO>(villa);
            _apiResponse.StatusCode = HttpStatusCode.OK;
            return CreatedAtRoute("GetVilla", new { id = villa.Id }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Success = false;
                _apiResponse.ErrorMessage = new List<string>() { ex.Message };
            }
            return _apiResponse;
        }

        // Update Villa Details
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaUpdateDTO)
        {
            if (villaUpdateDTO == null || id != villaUpdateDTO.Id)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var existingVilla = await _villaRepository.GetAsync(v => v.Id == id);
                if (existingVilla == null)
                {
                    return NotFound();
                }

                // Map updated properties
                existingVilla.Name = villaUpdateDTO.Name;
                existingVilla.Rate = villaUpdateDTO.Rate;
                existingVilla.SqFt = villaUpdateDTO.SqFt;
                existingVilla.Description = villaUpdateDTO.Description;
                existingVilla.ImageUrl = villaUpdateDTO.ImageUrl;
                existingVilla.Amenity = villaUpdateDTO.Amenity;

                await _villaRepository.UpdateAsync(existingVilla);

                return Ok(new APIResponse { Success = true, Result = existingVilla });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new APIResponse { Success = false, ErrorMessage = new List<string> { ex.Message } });
            }
        }

        // DELETE API start here
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _villaRepository.GetAsync(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                await _villaRepository.DeleteAsync(villa);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _apiResponse.Success = false;
                _apiResponse.ErrorMessage = new List<string>() { ex.Message };
            }
            return _apiResponse;
        }

    }

}
