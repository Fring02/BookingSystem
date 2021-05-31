using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Helpers.Exceptions;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Repositories.Users;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;

namespace Infrastructure.Services.Booking
{
    public class LeisureServicesService : BaseService<ILeisureServicesRepository, LeisureService>, ILeisureServicesService
    {
        private readonly ILeisureServicesCategoriesRepository _categoriesRepository;
        private readonly IOwnersRepository _ownersRepository;
        public LeisureServicesService(ILeisureServicesRepository repository, ILeisureServicesCategoriesRepository categoriesRepository,
            IOwnersRepository ownersRepository) : base(repository)
        {
            _categoriesRepository = categoriesRepository;
            _ownersRepository = ownersRepository;
        }

        public override async Task<LeisureService> CreateAsync(LeisureService model)
        {
            var category = await _categoriesRepository.GetByIdAsync(model.CategoryId).ConfigureAwait(false);
            if (category == null) throw new EntityNotFoundException("Such category does not exist");
            if (!await _ownersRepository.OwnerExists(model.OwnerId).ConfigureAwait(false)) throw new EntityNotFoundException("Such services owner doesn't exist");
            if (await _repository.ServiceExistsAsync(model.Name).ConfigureAwait(false)) throw new AlreadyPresentException("Service already exists");
            return await _repository.CreateAsync(model).ConfigureAwait(false);
        }
        public override async Task<bool> UpdateAsync(LeisureService model)
        {
            var category = await _categoriesRepository.GetByIdAsync(model.CategoryId);
            if (category == null)
            {
                throw new EntityNotFoundException("Category not found by id " + model.CategoryId);
            }
            return await _repository.UpdateAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByCategoryIdAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty) return null;
            return await _repository.GetByCategoryIdAsync(categoryId).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByFilterAsync(Guid categoryId = default, 
            string workingTime = null, int rating = 0)
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
            return await _repository.GetByPopularityAsync(count).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByName(string name)
        {
            return await _repository.GetByNameAsync(name).ConfigureAwait(false);
        }

        public async Task<IEnumerable<LeisureService>> GetByPageAsync(int page, int count)
        {
            return await _repository.GetByPageAsync(page, count).ConfigureAwait(false);
        }
    }
}