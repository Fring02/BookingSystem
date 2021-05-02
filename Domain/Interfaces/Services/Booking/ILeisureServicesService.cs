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
        Task<IEnumerable<LeisureService>> GetByCategoryId(Guid categoryId);
        Task<IEnumerable<LeisureService>> GetByFilter(Guid categoryId = default, string workingTime = null, int rating = 0);
        Task<bool> ServiceExists(string name);
    }
}