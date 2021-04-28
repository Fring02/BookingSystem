using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;

namespace Infrastructure.Services.Booking
{
    public class LeisureServicesService : ILeisureServicesService
    {
        private readonly ILeisureServicesRepository _repository;
        private readonly ILeisureServicesCategoriesRepository _categoriesRepository;
        public LeisureServicesService(ILeisureServicesRepository repository, ILeisureServicesCategoriesRepository categoriesRepository)
        {
            _repository = repository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<LeisureService> CreateAsync(LeisureService model)
        {
            var category = await _categoriesRepository.GetByIdAsync(model.CategoryId);
            if (category != null)
            {
              return await _repository.CreateAsync(model);
            }
            return null;
        }

        public Task<IEnumerable<LeisureService>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<LeisureService> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(LeisureService model)
        {
            return _repository.UpdateAsync(model);
        }

        public Task<bool> DeleteAsync(LeisureService model)
        {
            return _repository.DeleteAsync(model);
        }

        public Task<IEnumerable<LeisureService>> GetByRating(int rating)
        {
            return _repository.GetByRating(rating);
        }

        public Task<IEnumerable<LeisureService>> GetByWorkingTime(string workingTime)
        {
            return _repository.GetByWorkingTime(workingTime);
        }

        public Task<IEnumerable<LeisureService>> GetByCategoryId(Guid categoryId)
        {
            if (categoryId == Guid.Empty) return null;
            return _repository.GetByCategoryId(categoryId);
        }

        public Task<IEnumerable<LeisureService>> GetByFilter(Guid categoryId = default, string workingTime = null, int rating = 0)
        {
            if (categoryId == default && workingTime == null && rating == 0)
            {
                return GetAllAsync();
            }
            return _repository.GetByFilter(categoryId, workingTime, rating);
        }
    }
}