using AutoMapper;
using MagicVillaUdemy_Web.Models;
using MagicVillaUdemy_Web.Models.DTO;
using MagicVillaUdemy_Web.Services;
using MagicVillaUdemy_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVillaUdemy_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper; 
        }
        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> List = new();
            var Response = await _villaNumberService.GetAllAsync<APIResponse>();
            if (Response != null && Response.Success)
            {
                List = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(Response.Result));
            }
            return View(List);
        }
    }
}
