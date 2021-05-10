﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface IBookingRequestsService : IModelService<BookingRequest>
    {
        Task<IEnumerable<BookingRequest>> GetByServiceIdAsync(Guid serviceId);
        Task<IEnumerable<BookingRequest>> GetByUserIdAsync(Guid userId);
        Task<bool> HasRequestAsync(BookingRequest request);
    }
}