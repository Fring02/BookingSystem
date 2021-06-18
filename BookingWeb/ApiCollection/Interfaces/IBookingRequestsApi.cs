using BookingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.ApiCollection.Interfaces
{
    public interface IBookingRequestsApi
    {

        Task<bool> CreateBookingRequest(BookingRequestViewModel request, string token);
        Task<bool> CheckBookingRequest(BookingRequestViewModel request, string token);
        Task<bool> DeleteBookingRequest(Guid id, string token);
        Task<IEnumerable<BookingRequestViewModel>> GetRequestsByServiceId(Guid serviceid, string token = default);
    }
}
