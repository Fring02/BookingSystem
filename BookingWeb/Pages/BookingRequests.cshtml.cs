using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookingWeb.Pages
{
    public class BookingRequestsModel : PageModel
    {
        private readonly IBookingRequestsApi _bookingRequestsApi;
        private readonly IServicesApi _servicesApi;

        public BookingRequestsModel(IBookingRequestsApi bookingRequestsApi, IServicesApi servicesApi)
        {
            _bookingRequestsApi = bookingRequestsApi;
            _servicesApi = servicesApi;
        }

        [BindProperty]
        public LeisureServiceViewModel Service { get; set; }

        [BindProperty]
        public IEnumerable<BookingRequestViewModel> BookingRequests { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid serviceid)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("id")))
            {
                Guid id = Guid.Parse(HttpContext.Session.GetString("id"));

                if (id != Guid.Empty)
                {
                    string token = HttpContext.Session.GetString("token");

                    var model = await _bookingRequestsApi.GetRequestsByServiceId(serviceid, token);

                    if (model != null)
                    {
                        Console.WriteLine(model);
                        BookingRequests = model;
                    }

                    var res = await _servicesApi.GetServiceById(serviceid);
                    
                    Service = res;
                }
            }
            else
            {
                return RedirectToPage("Login");
            }

            return Page();
        }

    }
}