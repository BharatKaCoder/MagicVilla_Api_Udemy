using System.Diagnostics;
using AutoMapper;
using MagicVillaUdemy_Web.Models;
using MagicVillaUdemy_Web.Models.DTO;
using MagicVillaUdemy_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVillaUdemy_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IVillaService _VillService;
        private readonly IMapper _Mapper;

        public HomeController(IVillaService villaService, IMapper mapper)
        {
            _VillService = villaService;
            _Mapper = mapper;
        }

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> List = new();
            var Response = await _VillService.GetAllAsync<APIResponse>();
            if (Response != null && Response.Success)
            {
                List = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(Response.Result));
            }
            return View(List);
        }

    }
}
