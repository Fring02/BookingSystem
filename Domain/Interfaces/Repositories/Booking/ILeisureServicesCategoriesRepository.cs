using Domain.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface ILeisureServicesCategoriesRepository : IModelRepository<LeisureServiceCategory>
    {
        Task<LeisureServiceCategory> GetByName(string categoryName);
    }
}
