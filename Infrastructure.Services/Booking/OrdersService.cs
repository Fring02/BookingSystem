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
    public class OrdersService : BaseService<IOrdersRepository, Order, Guid> ,IOrdersService
    {
        private readonly ILeisureServicesRepository _servicesRepository;
        private readonly IUsersRepository _usersRepository;
        public OrdersService(IOrdersRepository repository, 
            ILeisureServicesRepository servicesRepository, 
            IUsersRepository usersRepository) : base(repository)
        {
            _servicesRepository = servicesRepository;
            _usersRepository = usersRepository;
        }

        public override async Task<Order> CreateAsync(Order model)
        {
            if (await _servicesRepository.GetByIdAsync(model.ServiceId) == null) throw new EntityNotFoundException("Not found service by id " + model.ServiceId);
            if(await _usersRepository.GetByIdAsync(model.UserId) == null) throw new EntityNotFoundException("Not found user by id " + model.UserId);
            if (await _repository.HasRequestAsync(model)) throw new AlreadyPresentException("This request already exists");
            return await base.CreateAsync(model);
        }

        public override async Task<Order> GetByIdAsync(Guid id)
        {
            if (id == default) return null;
            return await base.GetByIdAsync(id);
        }

        public override async Task<bool> UpdateAsync(Order model)
        {
            if (model.Id == default) return false;
            return await base.UpdateAsync(model);
        }

        public override async Task<bool> DeleteAsync(Order model)
        {
            if (model.Id == default) return false;
            return await base.DeleteAsync(model);
        }

        public async Task<IEnumerable<Order>> GetByServiceIdAsync(Guid serviceId)
        {
            if (serviceId == default) return null;
            return await _repository.GetByServiceIdAsync(serviceId).ConfigureAwait(false);
        }

        public async Task<bool> HasRequestAsync(Order request)
        {
            if (request.UserId == default || request.ServiceId == default) return false;
            return await _repository.HasRequestAsync(request).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId)
        {
            if (userId == default) return null;
            return await _repository.GetByUserIdAsync(userId).ConfigureAwait(false);
        }
    }
}