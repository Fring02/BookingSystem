using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Booking
{
    public class LeisureServicesCategoriesService : ILeisureServicesCategoriesService
    {
        private readonly ILeisureServicesCategoriesRepository _categoryRepository;

        public LeisureServicesCategoriesService(ILeisureServicesCategoriesRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<LeisureServiceCategory> GetByNameAsync(string categoryName)
        {
            return await _categoryRepository.GetByName(categoryName).ConfigureAwait(false);
        }

        public async Task<LeisureServiceCategory> CreateAsync(LeisureServiceCategory model)
        {
            return await _categoryRepository.CreateAsync(model).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(LeisureServiceCategory model)
        {
            return await _categoryRepository.DeleteAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureServiceCategory>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<LeisureServiceCategory> GetByIdAsync(Guid id)
        {
            return await _categoryRepository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(LeisureServiceCategory model)
        {
            return await _categoryRepository.UpdateAsync(model).ConfigureAwait(false);
        }
    }
}
