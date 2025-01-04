using MagicVilla_Api_Udemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_Api_Udemy.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/villaapi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {
        private readonly ILogger<VillaApiController> logger;
        public VillaApiController(ILogger<VillaApiController> _logger)
        {
            logger = _logger;
        }

        [HttpGet]
        public IEnumerable<VillaModel> GetVillas() 
        {
            logger.LogInformation("Getting All Villas");
            return new List<VillaModel>
            {
                new VillaModel { Id = 1, Name = "Beach View" },
                new VillaModel { Id = 2, Name = "Pool View" }
            };

        }
    }
}
