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

        public Task<BookingRequest> CreateAsync(BookingRequest model)
        {
            model.LeftAt = DateTime.Now;
            return _repository.CreateAsync(model);
        }

        public Task<IEnumerable<BookingRequest>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<BookingRequest> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty) return null;
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(BookingRequest model)
        {
            if (model.Id == Guid.Empty) return null;
            return _repository.UpdateAsync(model);
        }

        public Task<bool> DeleteAsync(BookingRequest model)
        {
            if (model.Id == Guid.Empty) return null;
            return _repository.DeleteAsync(model);
        }

        public Task<IEnumerable<BookingRequest>> GetByServiceId(Guid serviceId)
        {
            if (serviceId == Guid.Empty) return null;
            return _repository.GetByServiceId(serviceId);
        }
    }
}