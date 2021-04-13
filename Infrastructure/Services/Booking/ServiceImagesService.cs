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

        public Task<ServiceImage> CreateAsync(ServiceImage model)
        {
            return _repository.CreateAsync(model);
        }

        public Task<IEnumerable<ServiceImage>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<ServiceImage> GetByIdAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<bool> UpdateAsync(ServiceImage model)
        {
            return _repository.UpdateAsync(model);
        }

        public Task<bool> DeleteAsync(ServiceImage model)
        {
            return _repository.DeleteAsync(model);
        }

        public Task<IEnumerable<ServiceImage>> GetByServiceId(Guid serviceId)
        {
            return _repository.GetByServiceId(serviceId);
        }
    }
}