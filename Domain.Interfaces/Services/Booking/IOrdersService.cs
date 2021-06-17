using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface IOrdersService : IModelService<IOrdersRepository, Order, Guid>
    {
        Task<IEnumerable<Order>> GetByServiceIdAsync(Guid serviceId);
        Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
        Task<bool> HasRequestAsync(Order request);
    }
}