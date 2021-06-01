using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Users.PWA.Apis.Interfaces;
using Booking.Users.PWA.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Users.PWA.Controllers
{
    public class BookingRequestsController : Controller
    {
        private readonly IBookingRequestsApi _requestsApi;

        public BookingRequestsController(IBookingRequestsApi requestsApi)
        {
            _requestsApi = requestsApi;
        }

        public async Task<IActionResult> CreateBookingRequestAsync(BookingRequestViewModel request)
        {
            request.BookingTime = new TimeSpan(request.Days, request.Hours, request.Minutes, 0);
            if (await _requestsApi.CreateBookingRequest(request, HttpContext.Session.GetString("token"))) return Redirect("/services/" + request.ServiceId);
            else return Redirect("/services/" + request.ServiceId + "?reqError=Failed to order service");
        }


        public async Task<IActionResult> DeleteBookingRequestAsync(Guid id)
        {
            if(await _requestsApi.DeleteBookingRequest(id, HttpContext.Session.GetString("token")))
            {
                return RedirectToAction("ProfilePage", "Profile");
            } else
            {
                return RedirectToAction("ProfilePage", "Profile", new { reqError = "Failed to delete request" });
            }
        }

    }
}
