using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Core.Helpers;
using Domain.Core.Helpers.Exceptions;
using Domain.Core.Models.Booking;
using Domain.Dtos.Booking;
using Domain.Interfaces.Services.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("/api/v1/requests/")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _requestsService;
        private readonly IMapper _mapper;
        public OrdersController(IOrdersService requestsService, IMapper mapper)
        {
            _requestsService = requestsService;
            _mapper = mapper;
        }
        [Authorize(Roles = Roles.ADMIN)]
        [HttpGet]
        public async Task<IEnumerable<BookingRequestViewDto>> GetAllBookingRequestsAsync()
        {
            return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetAllAsync() ?? new List<Order>());
        }
        

        [HttpGet("serviceId={serviceId}")]
        public async Task<IEnumerable<BookingRequestViewDto>> GetBookingRequestsByServiceIdAsync(Guid serviceId)
        {
            return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetByServiceIdAsync(serviceId) ?? new List<Order>());
        }
        [HttpGet("userId={userId}")]
        public async Task<IEnumerable<BookingRequestViewDto>> GetBookingRequestsByUserIdAsync(Guid userId)
        {
            return _mapper.Map<IEnumerable<BookingRequestViewDto>>(await _requestsService.GetByUserIdAsync(userId) ?? new List<Order>());
        }

        [HttpGet("{id}")]
        public async Task<BookingRequestViewDto> GetBookingRequestByIdAsync(Guid id)
        {
            var request = await _requestsService.GetByIdAsync(id);
            return (request != null) ? _mapper.Map<BookingRequestViewDto>(request) : null;
        }
        [HttpGet("check/userId={userId}&serviceId={serviceId}")]
        public async Task<bool> CheckBookingRequest(Guid userId, Guid serviceId)
        {
           return await _requestsService.HasRequestAsync(new Order { UserId = userId, ServiceId = serviceId });
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookingRequestAsync(BookingRequestCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.Values.First().Errors.First();
                return BadRequest(error.ErrorMessage);
            }
            var model = _mapper.Map<Order>(dto);
            try
            {
                await _requestsService.CreateAsync(model);
                return Ok("Created new booking request");
            } catch (AlreadyPresentException e)
            {
                return BadRequest(e.Message);
            } 
            catch (EntityNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to create booking request");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBookingRequestAsync(Guid id, BookingRequestUpdateDto dto)
        {
            if (id == default) return BadRequest("Id for service is required");
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