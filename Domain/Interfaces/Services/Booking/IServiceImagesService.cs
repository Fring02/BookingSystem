using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface IServiceImagesService : IModelService<ServiceImage>
    {
        Task<IEnumerable<ServiceImage>> GetByServiceId(Guid serviceId);
    }
}