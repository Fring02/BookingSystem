using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;

namespace Infrastructure.Services.Booking
{
    public class BookingRequestsService : IBookingRequestsService
    {
        private readonly IBookingRequestsRepository _repository;

        public BookingRequestsService(IBookingRequestsRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookingRequest> CreateAsync(BookingRequest model)
        {
            return await _repository.CreateAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BookingRequest>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<BookingRequest> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return null;
            return await _repository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(BookingRequest model)
        {
            if (model.Id == Guid.Empty) return false;
            return await _repository.UpdateAsync(model).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(BookingRequest model)
        {
            if (model.Id == Guid.Empty) return false;
            return await _repository.DeleteAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BookingRequest>> GetByServiceId(Guid serviceId)
        {
            if (serviceId == Guid.Empty) return null;
            return await _repository.GetByServiceId(serviceId).ConfigureAwait(false);
        }

        public async Task<bool> HasRequest(BookingRequest request)
        {
            return await _repository.HasRequest(request).ConfigureAwait(false);
        }
    }
}