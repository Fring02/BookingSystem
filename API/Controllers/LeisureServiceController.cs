using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("services/")]
    public class LeisureServiceController : ControllerBase
    {
        private readonly ILeisureServicesService _leisureService;
        private readonly IMapper _mapper;
        public LeisureServiceController(ILeisureServicesService leisureService, IMapper mapper)
        {
            _leisureService = leisureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LeisureServiceDto>> GetAllLeisureServicesAsync()
        {
            return _mapper.Map<IEnumerable<LeisureServiceDto>>(await _leisureService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<LeisureServiceDto> GetLeisureServiceByIdAsync(Guid id)
        {
            var service = await _leisureService.GetByIdAsync(id);
            return service == null ? null : _mapper.Map<LeisureServiceDto>(service);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLeisureServiceAsync(LeisureServiceDto dto)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First();
                return BadRequest(error.ErrorMessage);
            }
            var model = _mapper.Map<LeisureService>(dto);
            model = await _leisureService.CreateAsync(model);
            if (model == null) return StatusCode(500, "Failed to create leisure service");
            return Ok("Created new leisure service");
        }
        
    }
}