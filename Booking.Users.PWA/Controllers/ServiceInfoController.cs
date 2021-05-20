using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Users.PWA.Apis.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Users.PWA.Controllers
{
    public class ServiceInfoController : Controller
    {
        private readonly IServicesApi _servicesApi;
        private readonly IBookingRequestsApi _requestsApi;
        public ServiceInfoController(IServicesApi servicesApi, IBookingRequestsApi requestsApi)
        {
            _servicesApi = servicesApi;
            _requestsApi = requestsApi;
        }
        [HttpGet("/services/{id}")]
        public async Task<IActionResult> ServiceInfoAsync(Guid id)
        {
            var service = await _servicesApi.GetServiceById(id);
            if(HttpContext.Session.Keys.Any())
            ViewBag.IsOrdered = await _requestsApi.CheckBookingRequest(new ViewModels.BookingRequestViewModel
            {
                ServiceId = id,
                UserId = Guid.Parse(HttpContext.Session.GetString("id"))
            }, HttpContext.Session.GetString("token"));
            return View(service);
        }


    }
}
