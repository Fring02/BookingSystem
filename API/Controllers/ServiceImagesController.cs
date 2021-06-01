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
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    //[Authorize(Roles = Roles.OWNER)]
    [Route("/api/v1/services/{id?}/images/")]
    public class ServiceImagesController : ControllerBase
    {
        private readonly IServiceImagesService _imagesService;
        private readonly IMapper _mapper;
        public ServiceImagesController(IServiceImagesService imagesService, IMapper mapper)
        {
            _imagesService = imagesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ServiceImageViewDto>> GetServiceImagesAsync(Guid id)
        {
            return _mapper.Map<IEnumerable<ServiceImageViewDto>>(await _imagesService.GetByServiceIdAsync(id));
        }

        [HttpGet("{imageId}")]
        public async Task<ServiceImageViewDto> GetServiceImageByIdAsync(Guid imageId)
        {
            var image = await _imagesService.GetByIdAsync(imageId);
            if (image == null) return null;
            return _mapper.Map<ServiceImageViewDto>(image);
        }

        [HttpPost]
        public async Task<IActionResult> CreateServiceImageAsync(Guid id, ServiceImageCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First();
                return BadRequest(error.ErrorMessage);
            }
            var model = _mapper.Map<ServiceImage>(dto);
            model.ServiceId = id;
            try
            {
                await _imagesService.CreateAsync(model);
                return Ok("Created image for service by id " + id);
            } catch
            {
                return StatusCode(500, "Failed to create image for service by id " + id);
            }
        }
        
        [HttpPut("{imageId}")]
        public async Task<IActionResult> UpdateServiceImageDto(Guid imageId, ServiceImageViewDto dto)
        {
            var model = await _imagesService.GetByIdAsync(imageId);
            if (model == null) return BadRequest("Can't find image by id " + imageId);
            UpdateImage(model, dto);
            if (await _imagesService.UpdateAsync(model)) return Ok("Updated image by id " + imageId);
            return StatusCode(500, "Failed to create image by id " + imageId);
        }

        [HttpDelete("{imageId}")]
        public async Task<IActionResult> DeleteServiceImageDto(Guid imageId)
        {
            var model = await _imagesService.GetByIdAsync(imageId);
            if (model == null) return BadRequest("Can't find image by id " + imageId);
            if (await _imagesService.DeleteAsync(model)) return Ok("Deleted image by id " + imageId);
            return StatusCode(500, "Failed to delete image by id " + imageId);
        }

        private void UpdateImage(ServiceImage model, ServiceImageViewDto dto)
        {
            if (dto.ServiceId != Guid.Empty) model.ServiceId = dto.ServiceId;
            if (!string.IsNullOrEmpty(dto.Path)) model.Path = dto.Path;
        }
    }
}