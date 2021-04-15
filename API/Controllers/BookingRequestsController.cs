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
        public async Task<IEnumerable<BookingRequestViewDto>> GetAllBookingRequestsAsync()
        {
            return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<BookingRequestViewDto> GetBookingRequestByIdAsync(Guid id)
        {
            return _mapper.Map<BookingRequestViewDto>(await _requestsService.GetByIdAsync(id));
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
            model = await _requestsService.CreateAsync(model);
            if (model == null) return StatusCode(500, "Failed to create booking request");
            return Ok("Created new booking request");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingRequestAsync(Guid id, BookingRequestUpdateDto dto)
        {
            var model = await _requestsService.GetByIdAsync(id);
            if (model == null) return BadRequest("Can't find booking request for id " + id);
            UpdateRequest(model, dto);
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

        private void UpdateRequest(BookingRequest model, BookingRequestUpdateDto dto)
        {
            if (dto.ServiceId != Guid.Empty) model.ServiceId = dto.ServiceId;
            if (dto.BookingTime != default) model.BookingTime = dto.BookingTime;
        }
    }
}