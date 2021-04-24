using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface ILeisureServicesService : IModelService<LeisureService>
    {
        Task<IEnumerable<LeisureService>> GetByRating(int rating);
        Task<IEnumerable<LeisureService>> GetByWorkingTime(string workingTime);
        Task<bool> CheckOwner(Guid ownerId);
    }
}