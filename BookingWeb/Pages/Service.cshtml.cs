using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingWeb.Pages
{
    public class ServiceModel : PageModel
    {
        private readonly IServicesApi _servicesApi;
        private readonly ICategoriesApi _categoriesApi;

        public ServiceModel(IServicesApi servicesApi, ICategoriesApi categoriesApi)
        {
            _servicesApi = servicesApi;
            _categoriesApi = categoriesApi;
        }

        [BindProperty]
        public IEnumerable<LeisureServiceViewModel> viewModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            //This is for saving user details to show on other pages
            ViewData["user"] = HttpContext.Session.GetString("user");

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("id")))
            {
                Guid id = Guid.Parse(HttpContext.Session.GetString("id"));

                if (id != Guid.Empty)
                {
                    string token = HttpContext.Session.GetString("token");

                    var model = await _servicesApi.GetOwnerService(id, token);

                    viewModel = model;
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
