using Booking.Users.PWA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis.Interfaces
{
    public interface ICategoriesApi
    {
        Task<IEnumerable<LeisureServiceCategoryViewModel>> GetAllCategories();
    }
}
