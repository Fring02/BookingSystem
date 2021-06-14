using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Helpers.Exceptions;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Booking;

namespace Infrastructure.Services.Booking
{
    public class BookingRequestsService : BaseService<IBookingRequestsRepository, BookingRequest> ,IBookingRequestsService
    {
        private readonly ILeisureServicesRepository _servicesRepository;
        private readonly IUsersRepository _usersRepository;
        public BookingRequestsService(IBookingRequestsRepository repository, 
            ILeisureServicesRepository servicesRepository, 
            IUsersRepository usersRepository) : base(repository)
        {
            _servicesRepository = servicesRepository;
            _usersRepository = usersRepository;
        }

        public override async Task<BookingRequest> CreateAsync(BookingRequest model)
        {
            if ((await _servicesRepository.GetByIdAsync(model.ServiceId)) == null) throw new EntityNotFoundException("Not found service by id " + model.ServiceId);
            if((await _usersRepository.GetByIdAsync(model.UserId)) == null) throw new EntityNotFoundException("Not found user by id " + model.UserId);
            if (await _repository.HasRequestAsync(model)) throw new AlreadyPresentException("This request already exists");
            return await _repository.CreateAsync(model);
        }

        public override async Task<BookingRequest> GetByIdAsync(Guid id)
        {
            if (id == default) return null;
            return await _repository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public override async Task<bool> UpdateAsync(BookingRequest model)
        {
            if (model.Id == default) return false;
            return await _repository.UpdateAsync(model).ConfigureAwait(false);
        }

        public override async Task<bool> DeleteAsync(BookingRequest model)
        {
            if (model.Id == default) return false;
            return await _repository.DeleteAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BookingRequest>> GetByServiceIdAsync(Guid serviceId)
        {
            if (serviceId == default) return null;
            return await _repository.GetByServiceIdAsync(serviceId).ConfigureAwait(false);
        }

        public async Task<bool> HasRequestAsync(BookingRequest request)
        {
            if (request.UserId == default || request.ServiceId == default) return false;
            return await _repository.HasRequestAsync(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<BookingRequest>> GetByUserIdAsync(Guid userId)
        {
            if (userId == default) return null;
            return await _repository.GetByUserIdAsync(userId).ConfigureAwait(false);
        }
    }
}