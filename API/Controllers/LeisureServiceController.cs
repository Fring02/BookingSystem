using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Services.Booking;
using Domain.Interfaces.Services.Users;
using Domain.Models.Booking;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/v1/services/")]
    public class LeisureServiceController : ControllerBase
    {
        private readonly ILeisureServicesService _leisureService;
        private readonly ILeisureServicesCategoriesService _categoryService;
        private readonly IOwnersService _ownersService;
        private readonly IMapper _mapper;
        public LeisureServiceController(ILeisureServicesService leisureService, IMapper mapper, ILeisureServicesCategoriesService categoryService, IOwnersService ownersService)
        {
            _leisureService = leisureService;
            _mapper = mapper;
            _categoryService = categoryService;
            _ownersService = ownersService;
        }

        [HttpGet]
        public async Task<IEnumerable<LeisureServiceViewDto>> GetAllLeisureServicesAsync(int rating, string startTime, string endTime, string categoryName)
        {
            IEnumerable<LeisureService> services;
            if (rating > 0)
            {
                services = await _leisureService.GetByRating(rating);
            }
            else if (!string.IsNullOrEmpty(categoryName))
            {
                var category = await _categoryService.GetByName(categoryName);
                if (category == null) return null;
                services = await _leisureService.GetByCategoryId(category.Id);
            }
            else if (!string.IsNullOrEmpty(startTime))
            {
                services = await _leisureService.GetByWorkingTime(startTime + "-24:00");
            }
            else if (!string.IsNullOrEmpty(endTime))
            {
                services = await _leisureService.GetByWorkingTime("00:00-" + endTime);
            }
            else services = await _leisureService.GetAllAsync();
            return _mapper.Map<IEnumerable<LeisureServiceViewDto>>(services ?? new List<LeisureService>());
        }

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
            var category = await _categoryService.GetByName(dto.CategoryName);
            if (category == null) return BadRequest("Such category doesn't exist.");
            if (!await _ownersService.OwnerExists(dto.OwnerId)) return BadRequest("Such services owner doesn't exist");
            var model = _mapper.Map<LeisureService>(dto);
            model.CategoryId = category.Id;
            model = await _leisureService.CreateAsync(model);
            if (model == null) return StatusCode(500, "Failed to create leisure service");
            return Ok("Created new leisure service");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeisureServiceAsync(LeisureServiceUpdateDto dto, Guid id)
        {
            var model = await _leisureService.GetByIdAsync(id);
            if (model == null) return BadRequest("Failed to find leisure service by id " + id);
            UpdateService(model, dto);
            if (!string.IsNullOrEmpty(dto.CategoryName))
            {
                var category = await _categoryService.GetByName(dto.CategoryName);
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