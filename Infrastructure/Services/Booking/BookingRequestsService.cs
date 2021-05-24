using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Helpers.Exceptions;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;

namespace Infrastructure.Services.Booking
{
    public class BookingRequestsService : IBookingRequestsService
    {
        private readonly IBookingRequestsRepository _repository;
        private readonly ILeisureServicesRepository _servicesRepository;
        private readonly IOwnersRepository _ownersRepository;
        public BookingRequestsService(IBookingRequestsRepository repository, ILeisureServicesRepository servicesRepository, IOwnersRepository ownersRepository)
        {
            _repository = repository;
            _servicesRepository = servicesRepository;
            _ownersRepository = ownersRepository;
        }

        public async Task<BookingRequest> CreateAsync(BookingRequest model)
        {
            if ((await _servicesRepository.GetByIdAsync(model.ServiceId)) == null) throw new EntityNotFoundException("Not found service by id " + model.ServiceId);
            if((await _ownersRepository.GetByIdAsync(model.UserId)) == null) throw new EntityNotFoundException("Not found user by id " + model.UserId);
            if (await _repository.HasRequestAsync(model)) throw new AlreadyPresentException("This request already exists");
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

        public async Task<IEnumerable<BookingRequest>> GetByServiceIdAsync(Guid serviceId)
        {
            if (serviceId == Guid.Empty) return null;
            return await _repository.GetByServiceIdAsync(serviceId).ConfigureAwait(false);
        }

        public async Task<bool> HasRequestAsync(BookingRequest request)
        {
            return await _repository.HasRequestAsync(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BookingRequest>> GetByUserIdAsync(Guid userId)
        {
            return await _repository.GetByUserIdAsync(userId).ConfigureAwait(false);
        }
    }
}