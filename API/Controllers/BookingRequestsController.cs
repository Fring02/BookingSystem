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
    [Authorize(Roles = Roles.USER)]
    [Route("/api/v1/requests/")]
    public class BookingRequestsController : ControllerBase
    {
        private readonly IBookingRequestsService _requestsService;
        private readonly IMapper _mapper;
        public BookingRequestsController(IBookingRequestsService requestsService, IMapper mapper)
        {
            _requestsService = requestsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<BookingRequestViewDto>> GetAllBookingRequestsAsync(Guid serviceId, Guid userId)
        {
            if(serviceId != default)
                return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetByServiceIdAsync(serviceId) ?? new List<BookingRequest>());
            if(userId != default)
                return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetByUserIdAsync(userId) ?? new List<BookingRequest>());

            return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetAllAsync() ?? new List<BookingRequest>());
        }

        [HttpGet("{id}")]
        public async Task<BookingRequestViewDto> GetBookingRequestByIdAsync(Guid id)
        {
            var request = await _requestsService.GetByIdAsync(id);
            return (request != null) ? _mapper.Map<BookingRequestViewDto>(request) : null;
        }
        [HttpGet("userId={userId}&serviceId={serviceId}")]
        public async Task<IActionResult> CheckBookingRequest(Guid userId, Guid serviceId)
        {
           if(await _requestsService.HasRequestAsync(new BookingRequest { UserId = userId, ServiceId = serviceId }))
            {
                return Ok("true");
            }
            return NotFound("false");
        }
        [HttpPost]
        public async Task<IActionResult> CreateBookingRequestAsync(BookingRequestCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First();
                return BadRequest(error.ErrorMessage);
            }
            var model = _mapper.Map<BookingRequest>(dto);
            if (await _requestsService.HasRequestAsync(model)) return BadRequest("This request already exists");
            model = await _requestsService.CreateAsync(model);
            if (model == null) return StatusCode(500, "Failed to create booking request");
            return Ok("Created new booking request");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingRequestAsync(Guid id, BookingRequestUpdateDto dto)
        {
            var model = await _requestsService.GetByIdAsync(id);
            if (model == null) return BadRequest("Can't find booking request for id " + id);
            if (dto.BookingTime != default) model.BookingTime = dto.BookingTime;
            if (!string.IsNullOrEmpty(dto.Info)) model.Info = dto.Info;
            if (await _requestsService.UpdateAsync(model)) return Ok("Updated booking request for id " + id);
            return StatusCode(500, "Failed to update booking request for id " + id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingRequestAsync(Guid id)
        {
            var model = await _requestsService.GetByIdAsync(id);
            if (model == null) return BadRequest("Can't find booking request for id " + id);
            if (await _requestsService.DeleteAsync(model)) return Ok("Deleted booking request for id " + id);
            return StatusCode(500, "Failed to delete booking request for id " + id);
        }
    }
}