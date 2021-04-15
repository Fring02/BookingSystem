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

        public Task<LeisureServiceCategory> GetByName(string categoryName)
        {
            return _categoryRepository.GetByName(categoryName);
        }

        public Task<LeisureServiceCategory> CreateAsync(LeisureServiceCategory model)
        {
            return _categoryRepository.CreateAsync(model);
        }

        public Task<bool> DeleteAsync(LeisureServiceCategory model)
        {
            return _categoryRepository.DeleteAsync(model);
        }

        public Task<IEnumerable<LeisureServiceCategory>> GetAllAsync()
        {
            return _categoryRepository.GetAllAsync();
        }

        public Task<LeisureServiceCategory> GetByIdAsync(Guid id)
        {
            return _categoryRepository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(LeisureServiceCategory model)
        {
            return _categoryRepository.UpdateAsync(model);
        }
    }
}
