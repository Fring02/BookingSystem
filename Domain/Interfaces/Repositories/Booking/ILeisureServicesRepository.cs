﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface ILeisureServicesRepository : IModelRepository<LeisureService>
    {
        Task<IEnumerable<LeisureService>> GetByRatingAsync(int rating);
        Task<IEnumerable<LeisureService>> GetByWorkingTimeAsync(string workingTime);
        Task<IEnumerable<LeisureService>> GetByCategoryIdAsync(Guid categoryId);
        Task<IEnumerable<LeisureService>> GetByOwnerIdAsync(Guid ownerId);
        Task<IEnumerable<LeisureService>> GetByFilterAsync(Guid categoryId = default, string workingTime = null, int rating = 0);
        Task<bool> ServiceExistsAsync(string name);
    }
}