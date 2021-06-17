using Domain.Core.Models.Booking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface IOrdersRepository : IModelRepository<Order, Guid>
    {
        Task<IEnumerable<Order>> GetByServiceIdAsync(Guid serviceId);
        Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
        Task<bool> HasRequestAsync(Order request);
    }
}