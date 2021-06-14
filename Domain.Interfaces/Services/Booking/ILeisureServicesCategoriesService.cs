using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Booking
{
    public interface ILeisureServicesCategoriesService : IModelService<ILeisureServicesCategoriesRepository, LeisureServiceCategory>
    {
        Task<LeisureServiceCategory> GetByNameAsync(string categoryName);
    }
}
