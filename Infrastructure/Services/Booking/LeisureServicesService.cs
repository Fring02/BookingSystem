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
        public LeisureServicesService(ILeisureServicesRepository repository)
        {
            _repository = repository;
        }

        public async Task<LeisureService> CreateAsync(LeisureService model)
        {
          return await _repository.CreateAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<LeisureService> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(LeisureService model)
        {
            if (model.Rating > 0) model.RatedCount++;
            return await _repository.UpdateAsync(model).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(LeisureService model)
        {
            return await _repository.DeleteAsync(model).ConfigureAwait(false);
        }


        public async Task<IEnumerable<LeisureService>> GetByCategoryIdAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty) return null;
            return await _repository.GetByCategoryIdAsync(categoryId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByFilterAsync(Guid categoryId = default, string workingTime = null, int rating = 0)
        {
            if (categoryId == default && workingTime == null && rating == 0)
            {
                return await GetAllAsync();
            }
            return await _repository.GetByFilterAsync(categoryId, workingTime, rating).ConfigureAwait(false);
        }

        public async Task<bool> ServiceExistsAsync(string name)
        {
            return await _repository.ServiceExistsAsync(name).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByOwnerIdAsync(Guid ownerId)
        {
            if (ownerId == default) return null;
            return await _repository.GetByOwnerIdAsync(ownerId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByPopularity(int count)
        {
            if (count <= 0) return null;
            return await _repository.GetByPopularity(count).ConfigureAwait(false);
        }
    }
}