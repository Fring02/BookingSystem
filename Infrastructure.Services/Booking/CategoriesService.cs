using System;
using Domain.Core.Helpers.Exceptions;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services.Booking;
using System.Threading.Tasks;

namespace Infrastructure.Services.Booking
{
    public class CategoriesService : BaseService<ICategoriesRepository, Category, Guid>,
        ICategoriesService
    {

        public CategoriesService(ICategoriesRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<Category> GetByNameAsync(string categoryName)
        {
            return await _repository.GetByNameAsync(categoryName).ConfigureAwait(false);
        }

        public override async Task<Category> CreateAsync(Category model)
        {
            if(await _repository.GetByNameAsync(model.Name) != null)
            {
                throw new AlreadyPresentException("This category already exists");
            }
            return await base.CreateAsync(model);
        }

    }
}
