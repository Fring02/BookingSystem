using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Users.PWA.Apis.Interfaces;
using Booking.Users.PWA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Users.PWA.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesApi _servicesApi;
        private readonly ICategoriesApi _categoriesApi;
        public ServicesController(IServicesApi servicesApi, ICategoriesApi categoriesApi)
        {
            _servicesApi = servicesApi;
            _categoriesApi = categoriesApi;
        }
        [HttpGet("/services")]
        public async Task<IActionResult> ServicesSectionAsync(string category = null)
        {
            IEnumerable<LeisureServiceElementViewModel> services;
            if (!string.IsNullOrEmpty(category)) services = await _servicesApi.GetFilteredServices(category);
            else services = await _servicesApi.GetAllServices();
            var categories = await _categoriesApi.GetAllCategories();
            return View(new ServicesSectionViewModel
            {
                Services = services,
                Categories = categories
            });
        }

        [HttpPost("/services")]
        public async Task<IActionResult> FilterServicesAsync(FilterFormViewModel filter, string name)
        {
            var services = await _servicesApi.GetFilteredServices(filter.CategoryName, filter.Rating, filter.WorkingTime, name);
            var categories = await _categoriesApi.GetAllCategories();
            return View("ServicesSection",new ServicesSectionViewModel
            {
                Services = services,
                Categories = categories
            });
        }
    }
}
