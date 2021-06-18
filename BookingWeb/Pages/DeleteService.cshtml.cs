using BookingWeb.ApiCollection.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace BookingWeb.Pages
{
    public class DeleteServiceModel : PageModel
    {
        private readonly IServicesApi _servicesApi;

        public DeleteServiceModel(IServicesApi servicesApi)
        {
            _servicesApi = servicesApi;
        }

        public async Task<IActionResult> OnGetAsync(Guid serviceid)
        {
            //This is for saving user details to show on other pages
            ViewData["user"] = HttpContext.Session.GetString("user");

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("id")))
            {
                Guid id = Guid.Parse(HttpContext.Session.GetString("id"));

                if (id != Guid.Empty)
                {
                    string token = HttpContext.Session.GetString("token");

                    var msg = await _servicesApi.DeleteService(serviceid, token);

                    ViewData["message"] = msg;
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
