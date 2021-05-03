using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.Booking;

namespace Domain.Interfaces.Services.Booking
{
    public interface IBookingRequestsService : IModelService<BookingRequest>
    {
        Task<IEnumerable<BookingRequest>> GetByServiceId(Guid serviceId);
        Task<bool> HasRequest(BookingRequest request);
    }
}