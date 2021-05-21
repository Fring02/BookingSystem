﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface ILeisureServicesService : IModelService<LeisureService>
    {
        Task<IEnumerable<LeisureService>> GetByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<LeisureService>> GetByOwnerIdAsync(Guid ownerId);
        Task<IEnumerable<LeisureService>> GetByName(string name);
        Task<IEnumerable<LeisureService>> GetByPopularity(int count);
        Task<IEnumerable<LeisureService>> GetByFilterAsync(Guid categoryId = default, string workingTime = null, int rating = 0);
        Task<bool> ServiceExistsAsync(string name);
    }
}