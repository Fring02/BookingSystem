using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;

namespace Infrastructure.Services.Booking
{
    public class LeisureServicesService : ILeisureServicesService
    {
        private readonly ILeisureServiceRepository _repository;

        public LeisureServicesService(ILeisureServiceRepository repository)
        {
            _repository = repository;
        }

        public Task<LeisureService> CreateAsync(LeisureService model)
        {
            return _repository.CreateAsync(model);
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
    }
}