using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;

namespace Infrastructure.Services.Booking
{
    public class ServiceImagesService : IServiceImagesService
    {
        private readonly IServiceImageRepository _repository;

        public ServiceImagesService(IServiceImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceImage> CreateAsync(ServiceImage model)
        {
            return await _repository.CreateAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ServiceImage>> GetAllAsync()
        {
            return await _repository.GetAllAsync().ConfigureAwait(false);
        }

        public async Task<ServiceImage> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id).ConfigureAwait(false);
        }

        public async Task<bool> UpdateAsync(ServiceImage model)
        {
            return await _repository.UpdateAsync(model).ConfigureAwait(false);
        }

        public async Task<bool> DeleteAsync(ServiceImage model)
        {
            return await _repository.DeleteAsync(model).ConfigureAwait(false);
        }

        public async Task<IEnumerable<ServiceImage>> GetByServiceId(Guid serviceId)
        {
            return await _repository.GetByServiceId(serviceId).ConfigureAwait(false);
        }
    }
}