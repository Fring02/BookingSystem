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
            return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetAllAsync() ?? new List<BookingRequest>());
        }

        [HttpGet("{id}")]
        public async Task<BookingRequestViewDto> GetBookingRequestByIdAsync(Guid id)
        {
            var request = await _requestsService.GetByIdAsync(id);
            return (request != null) ? _mapper.Map<BookingRequestViewDto>(request) : null;
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
            if (await _requestsService.HasRequest(model)) return BadRequest("This request already exists");
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