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
        private readonly ILogger<HomeController> _logger;
        //private readonly IVillaService _VillService;
        //private readonly IMapper _Mapper;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_VillService = villaService;
            //_Mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<IActionResult> IndexVilla()
        //{
        //    List<VillaDTO> List = new();
        //    var Response = await _VillService.GetAllAsync<APIResponse>();
        //    if (Response != null && Response.Success)
        //    {
        //        List = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(Response.Result));
        //    }
        //    return View(List);
        //}

    }
}
