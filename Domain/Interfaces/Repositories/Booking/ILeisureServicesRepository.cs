using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface ILeisureServicesRepository : IModelRepository<LeisureService>
    {
        Task<IEnumerable<LeisureService>> GetByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<LeisureService>> GetByPopularityAsync(int count);
        Task<IEnumerable<LeisureService>> GetByNameAsync(string name);
        Task<IEnumerable<LeisureService>> GetByPageAsync(int page, int count);
        Task<IEnumerable<LeisureService>> GetByOwnerIdAsync(Guid ownerId);
        Task<IEnumerable<LeisureService>> GetByFilterAsync(Guid categoryId = default, string workingTime = null, int rating = 0);
        Task<bool> ServiceExistsAsync(string name);
    }
}