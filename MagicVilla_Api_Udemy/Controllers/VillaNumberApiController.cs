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
    [Route("api/villnumberaapi")]
    [ApiController]
    public class VillaNumberApiController : ControllerBase
    {
        private readonly ILogger<VillaNumberApiController> logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IVillaNumberRepository _DbvillaNumber;
        private readonly IVillaRepository _DbvillaRepo;
        private readonly IMapper _mapper;
        private readonly APIResponse _apiResponse;

        public VillaNumberApiController(ILogger<VillaNumberApiController> _logger, IVillaRepository DbVillRepo, IVillaNumberRepository villaNumber, IMapper mapper)
        {
            logger = _logger;
            _DbvillaNumber = villaNumber;
            _mapper = mapper;
            _apiResponse = new();
            _DbvillaRepo = DbVillRepo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        public async Task<ActionResult <APIResponse>> GetVillasNumber() 
        {
            try
            {
                logger.LogInformation("Getting All Villas");
                var VillaNumberList = await _DbvillaNumber.GetAllNumberAsync();
                _apiResponse.Result = _mapper.Map<List<VillaNumberDTO>>(VillaNumberList);
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

        [HttpGet("int{id}", Name ="GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)] // This is response types
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillasNumberById(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var Villas = await _DbvillaNumber.GetNumberAsync(x => x.VillaNo == id);

                if (Villas == null)
                {
                    return NotFound();
                }
                _apiResponse.Result = _mapper.Map<VillaNumberDTO>(Villas);
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

        // POST API start here
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task <ActionResult<APIResponse>> CreateVilla([FromBody] VillaNumberCreateDTO _createvillaDTO)
        {
            try
            {
            var villsList = await _DbvillaNumber.GetNumberAsync(u => u.VillaNo == _createvillaDTO.VillaNo) != null;
            if (villsList)
            {
                ModelState.AddModelError("CustomError", "Villa number already exist!");
                return BadRequest(ModelState);
            }
            if(await _DbvillaRepo.GetAsync(x=>x.Id == _createvillaDTO.VillaID)== null)
                {
                    ModelState.AddModelError("CustomError", "Villa ID is invalid");
                    return BadRequest(ModelState);
                }
            if (_createvillaDTO == null)
            {
                return BadRequest(_createvillaDTO);
            }

            var villa = _mapper.Map<VillaNumber>(_createvillaDTO);
            await _DbvillaNumber.CreateNumberAsync(villa);
            _apiResponse.Result = _mapper.Map<VillaNumberDTO>(villa);
            _apiResponse.StatusCode = HttpStatusCode.OK;
            return CreatedAtRoute("GetVilla", new { id = villa.VillaNo }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.Success = false;
                _apiResponse.ErrorMessage = new List<string>() { ex.Message };
            }
            return _apiResponse;
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
                if(id == 0)
                {
                    return BadRequest();
                }
                var villa = await _DbvillaNumber.GetNumberAsync(u=>u.VillaNo == id);
                if(villa == null)
                {
                    return NotFound();
                }
                await _DbvillaNumber.RemoveNumberAsync(villa);
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
