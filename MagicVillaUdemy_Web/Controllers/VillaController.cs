using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using MagicVillaUdemy_Web.Models;
using MagicVillaUdemy_Web.Models.DTO;
using MagicVillaUdemy_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVillaUdemy_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _VillService;
        private readonly IMapper _Mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
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

        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var Response = await _VillService.CreateAsync<APIResponse>(model);
                if (Response != null && Response.Success)
                {
                    TempData["success"] = "Villa updated successfully!";
                    return RedirectToAction(nameof(IndexVilla));
                }
                TempData["error"] = "Something went wrong!";
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateVilla(int VillaId)
        {
            var Response = await _VillService.GetAsync<APIResponse>(VillaId);
            if (Response != null && Response.Success)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(Response.Result));
                return View(_Mapper.Map<VillaUpdateDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var Response = await _VillService.UpdateAsync<APIResponse>(dto);
                if (Response != null && Response.Success)
                {
                    TempData["success"] = "Villa updated successfully!";
                    return RedirectToAction(nameof(IndexVilla));
                }
                TempData["error"] = "Something went wrong!";
            }
            return View(dto);
        }

        // Delete Villa 
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            var response = await _VillService.GetAsync<APIResponse>(villaId);
            if (response != null && response.Success)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        // POST: Perform the deletion
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaConfirmed(VillaDTO model)
        {
            var response = await _VillService.DeleteAsync<APIResponse>(model.Id); // Pass the ID to delete
            if (response != null && response.Success)
            {
                TempData["success"] = "Villa deleted successfully!";
                return RedirectToAction(nameof(IndexVilla));
            }
            TempData["error"] = "Something went wrong!";
            return View(model); // Optionally return a view with an error message
        }
    }
}
