using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Models.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface IServiceImagesService : IModelService<IServiceImageRepository, ServiceImage>
    {
        Task<IEnumerable<ServiceImage>> GetByServiceIdAsync(Guid serviceId);
    }
}