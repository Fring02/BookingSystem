using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface IServiceImageRepository : IModelRepository<ServiceImage>
    {
        Task<IEnumerable<ServiceImage>> GetByServiceIdAsync(Guid serviceId);
    }
}