using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Helpers;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/v1/categories")]
    //[Authorize(Roles = Roles.ADMIN)]
    [ApiController]
    public class LeisureServiceCategoriesController : ControllerBase
    {
        private readonly ILeisureServicesCategoriesService _categoryService;
        private readonly IMapper _mapper;
        public LeisureServiceCategoriesController(IMapper mapper, ILeisureServicesCategoriesService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<LeisureServiceCategoryViewDto>> GetAllCategoriesAsync()
        {
            return _mapper.Map<IEnumerable<LeisureServiceCategoryViewDto>>(await _categoryService.GetAllAsync());
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<LeisureServiceCategoryViewDto> GetLeisureServiceCategoryByIdAsync(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<LeisureServiceCategoryViewDto>(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeisureServiceCategoryAsync(LeisureServiceCategoryCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First();
                return BadRequest(error.ErrorMessage);
            }
            if ((await _categoryService.GetByNameAsync(dto.Name)) != null) return BadRequest("This category already exists");
            var model = _mapper.Map<LeisureServiceCategory>(dto);
            model = await _categoryService.CreateAsync(model);
            if (model == null) return StatusCode(500, "Failed to create leisure service category");
            return Ok("Created new leisure service category");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLeisureServiceCategoryAsync(LeisureServiceCategoryUpdateDto dto, Guid id)
        {
            var model = await _categoryService.GetByIdAsync(id);
            if (model == null) return BadRequest("Failed to find leisure service category by id " + id);
            if (string.IsNullOrEmpty(dto.Name)) return BadRequest("Enter new category name");
            model.Name = dto.Name;
            if (await _categoryService.UpdateAsync(model)) return Ok("Updated leisure service category by id " + id);
            return BadRequest("Failed to update leisure service category by id" + id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeisureServiceCategoryAsync(Guid id)
        {
            var model = await _categoryService.GetByIdAsync(id);
            if (model == null) return BadRequest("Failed to find leisure service category by id " + id);
            if (await _categoryService.DeleteAsync(model)) return Ok("Deleted leisure service category by id " + id);
            return BadRequest("Failed to delete leisure service category by id " + id);
        }
    }
}
