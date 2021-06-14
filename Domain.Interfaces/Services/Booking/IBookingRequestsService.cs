using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Core.Models.Booking;
using Domain.Interfaces.Repositories.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface IBookingRequestsService : IModelService<IBookingRequestsRepository, BookingRequest>
    {
        Task<IEnumerable<BookingRequest>> GetByServiceIdAsync(Guid serviceId);
        Task<IEnumerable<BookingRequest>> GetByUserIdAsync(Guid userId);
        Task<bool> HasRequestAsync(BookingRequest request);
    }
}