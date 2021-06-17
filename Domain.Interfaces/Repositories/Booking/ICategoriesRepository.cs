using Domain.Core.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface ICategoriesRepository : IModelRepository<Category, Guid>
    {
        Task<Category> GetByNameAsync(string categoryName);
    }
}
