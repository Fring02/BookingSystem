using Booking.Users.PWA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis.Interfaces
{
    public interface IServicesApi
    {
        Task<IEnumerable<LeisureServiceElementViewModel>> GetPopularServices(int count);
        Task<bool> UpdateService(Guid id, int rating, string token);
        Task<IEnumerable<LeisureServiceElementViewModel>> GetAllServices();
        Task<IEnumerable<LeisureServiceElementViewModel>> GetFilteredServices(string categoryName = null, int? rating = null, string workingTime = null, string name = null);
        Task<LeisureServiceViewModel> GetServiceById(Guid id);
    }
}
