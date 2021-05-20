﻿using Booking.Users.PWA.ViewModels;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis.Interfaces
{
    public interface IServicesApi
    {
        Task<IEnumerable<LeisureServiceElementViewModel>> GetPopularServices(int count);
        Task<IEnumerable<LeisureServiceElementViewModel>> GetAllServices();
        Task<IEnumerable<LeisureServiceElementViewModel>> GetFilteredServices(string categoryName = null, int? rating = null, string workingTime = null);
        Task<LeisureServiceViewModel> GetServiceById(Guid id);
    }
}
