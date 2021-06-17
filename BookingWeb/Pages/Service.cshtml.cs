using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.Models;
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

        public async Task<IActionResult> OnGetAsync(string category = null)
        {
            IEnumerable<LeisureServiceElementViewModel> services;
            if (!string.IsNullOrEmpty(category)) services = await _servicesApi.GetFilteredServices(category);
            else services = await _servicesApi.GetAllServices();
            var categories = await _categoriesApi.GetAllCategories();
            var service = new ServicesSectionViewModel
            {
                Services = services,
                Categories = categories
            };
            return Page();
        }
    }
}
