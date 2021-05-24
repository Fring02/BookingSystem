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
        public async Task<IActionResult> ServiceInfoAsync(Guid id, string ratingError)
        {
            var service = await _servicesApi.GetServiceById(id);
            if (!string.IsNullOrEmpty(ratingError)) ViewBag.RatingError = ratingError;
            if(HttpContext.Session.Keys.Any())
            ViewBag.IsOrdered = await _requestsApi.CheckBookingRequest(new ViewModels.BookingRequestViewModel
            {
                ServiceId = id,
                UserId = Guid.Parse(HttpContext.Session.GetString("id"))
            }, HttpContext.Session.GetString("token"));
            return View(service);
        }
        [HttpPost("/services/{id}")]
        public async Task<IActionResult> UpdateServiceAsync(Guid id, int rating)
        {
            string token = HttpContext.Session.GetString("token");
            if (string.IsNullOrEmpty(token)) return RedirectToAction("Index", "Home");
            if (!await _servicesApi.UpdateService(id, rating, token)) return Redirect("/services/" + id + "?ratingError=Failed to put rating");
            return Redirect("/services/" + id);
        }

    }
}
