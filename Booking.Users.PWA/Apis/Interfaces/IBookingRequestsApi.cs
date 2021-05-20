using Booking.Users.PWA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Booking.Users.PWA.Apis.Interfaces
{
    public interface IBookingRequestsApi
    {
        Task<bool> CreateBookingRequest(BookingRequestViewModel request, string token = default);
        Task<bool> CheckBookingRequest(BookingRequestViewModel request, string token = default);
    }
}
