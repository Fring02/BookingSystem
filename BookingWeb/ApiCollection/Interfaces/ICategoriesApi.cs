using BookingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.Interfaces
{
    public interface ICategoriesApi
    {

        Task<IEnumerable<LeisureServiceCategoryViewModel>> GetAllCategories();
    }
}
