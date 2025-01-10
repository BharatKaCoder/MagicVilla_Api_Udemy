using System.Collections.Generic;
using AutoMapper;
using MagicVillaUdemy_Web.Models;
using MagicVillaUdemy_Web.Models.DTO;
using MagicVillaUdemy_Web.Models.ViewModel;
using MagicVillaUdemy_Web.Services;
using MagicVillaUdemy_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MagicVillaUdemy_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaNumberController(IVillaNumberService villaNumberService, IVillaService villaService, IMapper mapper)
        {
            _villaNumberService = villaNumberService;
            _villaService = villaService;
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
        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM vm = new VillaNumberCreateVM();

            // Fetch the list of villas
            var response = await _villaService.GetAllAsync<APIResponse>();

            // Check if the response is successful
            if (response != null && response.Success)
            {
                // Deserialize the result into a list of VillaDTOs
                var villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));

                // Check if villaList is not null before proceeding
                if (villaList != null && villaList.Any())
                {
                    // Populate the VillaList property in the ViewModel
                    vm.VillaList = villaList.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    }).ToList(); // Convert to List<SelectListItem>
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No villas found.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Failed to load villa list.");
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var Response = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber);
                if (Response != null && Response.Success)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                } else
                {
                    if(Response.ErrorMessage.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessage",Response.ErrorMessage.FirstOrDefault());
                    }
                }
            }

            // To poplate dropdown option again

            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.Success)
            {
                var villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
                if (villaList != null && villaList.Any())
                {
                    model.VillaList = villaList.Select(x => new SelectListItem
                    {
                        Text = x.Name,
                        Value = x.Id.ToString(),
                    }).ToList(); // Convert to List<SelectListItem>
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "No villas found.");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateVillaNumber(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);
            if (response != null && response.Success)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<VillaUpdateDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaUpdateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var response = await _villaService.UpdateAsync<APIResponse>(dto);
                if (response != null && response.Success)
                {
                    return RedirectToAction(nameof(IndexVillaNumber));
                }
            }
            return View(dto);
        }

        public async Task<IActionResult> DeleteVillaNumber(int villaId)
        {
            var response = await _villaService.GetAsync<APIResponse>(villaId);
            if (response != null && response.Success)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumberConfirmed(int id)
        {
            var response = await _villaService.DeleteAsync<APIResponse>(id); // Pass the ID to delete
            if (response != null && response.Success)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }

            ModelState.AddModelError(string.Empty, "Failed to delete villa number.");
            return View(); // Optionally return a view with an error message
        }

    }
}
