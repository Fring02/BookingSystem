using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface IServiceImageRepository : IModelRepository<ServiceImage>
    {
        Task<IEnumerable<ServiceImage>> GetByServiceId(Guid serviceId);
    }
}