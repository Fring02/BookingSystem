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
        public ServicesSectionViewModel serviceModel { get; set; }
        public LeisureServiceViewModel viewModel { get; set; }

        public async Task<IActionResult> OnGetAsync(string category = null)
        {
            //This is for saving user details to show on other pages
            ViewData["user"] = HttpContext.Session.GetString("user");

            IEnumerable<LeisureServiceElementViewModel> services;
            if (!string.IsNullOrEmpty(category)) services = await _servicesApi.GetFilteredServices(category);
            else services = await _servicesApi.GetAllServices();
            var categories = await _categoriesApi.GetAllCategories();
            serviceModel = new ServicesSectionViewModel
            {
                Services = services,
                Categories = categories
            };
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            string userId = HttpContext.Session.GetString("userId");
            var viewModel = new LeisureServiceViewModel
            {

            };
            return Page();
        }
    }
}
