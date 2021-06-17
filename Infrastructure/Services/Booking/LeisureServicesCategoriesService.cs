using Domain.Helpers.Exceptions;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Booking
{
    public class LeisureServicesCategoriesService : BaseService<ILeisureServicesCategoriesRepository, LeisureServiceCategory>,
        ILeisureServicesCategoriesService
    {

        public LeisureServicesCategoriesService(ILeisureServicesCategoriesRepository categoryRepository) : base(categoryRepository)
        {
        }

        public async Task<LeisureServiceCategory> GetByNameAsync(string categoryName)
        {
            return await _repository.GetByName(categoryName).ConfigureAwait(false);
        }

        public override async Task<LeisureServiceCategory> CreateAsync(LeisureServiceCategory model)
        {
            if((await _repository.GetByName(model.Name)) != null)
            {
                throw new AlreadyPresentException("This category already exists");
            }
            return await _repository.CreateAsync(model).ConfigureAwait(false);
        }

    }
}
