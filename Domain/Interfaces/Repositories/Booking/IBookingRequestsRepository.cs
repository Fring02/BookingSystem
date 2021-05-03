using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Repositories.Booking
{
    public interface IBookingRequestsRepository : IModelRepository<BookingRequest>
    {
        Task<IEnumerable<BookingRequest>> GetByServiceId(Guid serviceId);
        Task<IEnumerable<BookingRequest>> GetByUserId(Guid userId);
        Task<bool> HasRequest(BookingRequest request);
    }
}