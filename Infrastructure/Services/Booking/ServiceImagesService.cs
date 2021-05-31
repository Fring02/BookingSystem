﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces.Repositories.Booking;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Booking;
using Domain.Models.Booking;
using Infrastructure.Repositories.Booking;

namespace Infrastructure.Services.Booking
{
    public class ServiceImagesService : BaseService<IServiceImageRepository, ServiceImage>, IServiceImagesService
    {

        public ServiceImagesService(IServiceImageRepository repository) : base(repository)
        {
        }

        public async Task<IEnumerable<ServiceImage>> GetByServiceIdAsync(Guid serviceId)
        {
            return await _repository.GetByServiceIdAsync(serviceId).ConfigureAwait(false);
        }
    }
}