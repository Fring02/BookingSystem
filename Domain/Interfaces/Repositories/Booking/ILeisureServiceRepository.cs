using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface ILeisureServiceRepository : IModelRepository<LeisureService>
    {
        Task<IEnumerable<LeisureService>> GetByRating(int rating);
        Task<IEnumerable<LeisureService>> GetByWorkingTime(string workingTime);
    }
}