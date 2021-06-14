using Domain.Core.Models.Booking;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface IBookingRequestsRepository : IModelRepository<BookingRequest>
    {
        Task<IEnumerable<BookingRequest>> GetByServiceIdAsync(Guid serviceId);
        Task<IEnumerable<BookingRequest>> GetByUserIdAsync(Guid userId);
        Task<bool> HasRequestAsync(BookingRequest request);
    }
}