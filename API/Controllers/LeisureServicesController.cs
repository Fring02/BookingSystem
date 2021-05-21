using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Helpers;
using Domain.Interfaces.Services.Booking;
using Domain.Interfaces.Services.Users;
using Domain.Models.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    //[Authorize(Roles = Roles.OWNER)]
    [Route("/api/v1/services/")]
    public class LeisureServicesController : ControllerBase
    {
        private readonly ILeisureServicesService _leisureService;
        private readonly ILeisureServicesCategoriesService _categoryService;
        private readonly IOwnersService _ownersService;
        private readonly IMapper _mapper;
        public LeisureServicesController(ILeisureServicesService leisureService, IMapper mapper, ILeisureServicesCategoriesService categoryService, IOwnersService ownersService)
        {
            _leisureService = leisureService;
            _mapper = mapper;
            _categoryService = categoryService;
            _ownersService = ownersService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<LeisureServiceViewDto>> GetAllLeisureServicesAsync(int? rating, string workingTime = null, 
            string categoryName = null, string name = null)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return _mapper.Map<IEnumerable<LeisureServiceViewDto>>(await _leisureService.GetByName(name));
            }
            Guid categoryId = default;
            if (!string.IsNullOrEmpty(categoryName))
            {
                var category = await _categoryService.GetByNameAsync(categoryName);
                if (category == null) return null;
                categoryId = category.Id;
            }
            return _mapper.Map<IEnumerable<LeisureServiceViewDto>>(await _leisureService.GetByFilterAsync(categoryId, workingTime, rating.GetValueOrDefault())
                ?? new List<LeisureService>());
        }

        [AllowAnonymous]
        [HttpGet("popular")]
        public async Task<IEnumerable<LeisureServiceViewDto>> GetPopularLeisureServicesAsync(int count)
        {
            return _mapper.Map<IEnumerable<LeisureServiceViewDto>>(await _leisureService.GetByPopularity(count)
                ?? new List<LeisureService>());
        }

        [HttpGet("ownerId={ownerId}")]
        public async Task<IEnumerable<LeisureServiceViewDto>> GetLeisureServicesByOwnerId(Guid ownerId)
        {
            var services = await _leisureService.GetByOwnerIdAsync(ownerId);
            if (services == null) return null;
            return _mapper.Map<IEnumerable<LeisureServiceViewDto>>(services);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<LeisureServiceViewDto> GetLeisureServiceByIdAsync(Guid id)
        {
            var service = await _leisureService.GetByIdAsync(id);
            return service == null ? null : _mapper.Map<LeisureServiceViewDto>(service);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeisureServiceAsync(LeisureServiceCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First();
                return BadRequest(error.ErrorMessage);
            }
            var category = await _categoryService.GetByIdAsync(dto.CategoryId);
            if (category == null) return BadRequest("Such category doesn't exist.");
            if (!await _ownersService.OwnerExists(dto.OwnerId)) return BadRequest("Such services owner doesn't exist");
            if (await _leisureService.ServiceExistsAsync(dto.Name)) return BadRequest("Service already exists");
            var model = _mapper.Map<LeisureService>(dto);
            model = await _leisureService.CreateAsync(model);
            if (model == null) return StatusCode(500, "Failed to create leisure service");
            return Ok("Created new leisure service");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeisureServiceAsync(LeisureServiceUpdateDto dto, Guid id)
        {
            var model = await _leisureService.GetByIdAsync(id);
            if (model == null) return BadRequest("Failed to find leisure service by id " + id);
            if (dto.Rating > 5) return BadRequest("Max rating is 5");
            UpdateService(model, dto);
            if (Guid.Empty != dto.CategoryId)
            {
                var category = await _categoryService.GetByIdAsync(dto.CategoryId);
                if(category != null)
                model.CategoryId = category.Id;
            }
            if (await _leisureService.UpdateAsync(model)) return Ok("Updated leisure service by id " + id);
            return BadRequest("Failed to update leisure service by id" + id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeisureServiceAsync(Guid id)
        {
            var model = await _leisureService.GetByIdAsync(id);
            if (model == null) return BadRequest("Failed to find leisure service by id " + id);
            if (await _leisureService.DeleteAsync(model)) return Ok("Deleted leisure service by id " + id);
            return BadRequest("Failed to delete leisure service by id " + id);
        }


        private static void UpdateService(LeisureService model, LeisureServiceUpdateDto dto)
        {
            if (!string.IsNullOrEmpty(dto.Name)) model.Name = dto.Name;
            if (!string.IsNullOrEmpty(dto.Location)) model.Location = dto.Location;
            if (!string.IsNullOrEmpty(dto.Website)) model.Website = dto.Website;
            if (!string.IsNullOrEmpty(dto.Description)) model.Description = dto.Description;
            if (!string.IsNullOrEmpty(dto.WorkingTime)) model.WorkingTime = dto.WorkingTime;
            if (dto.Rating > 0) model.Rating = dto.Rating;
        }
    }
}