using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Booking.Users.PWA.Apis.Interfaces;
using Booking.Users.PWA.ViewModels;

namespace Booking.Users.PWA.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicesApi _servicesApi;
        private readonly ICategoriesApi _categoriesApi;
        public HomeController(IServicesApi api, ICategoriesApi categoriesApi)
        {
            _servicesApi = api;
            _categoriesApi = categoriesApi;
        }

        public async Task<IActionResult> IndexAsync(string loginError, string registerError)
        {
            var services = await _servicesApi.GetPopularServices(3);
            var categories = await _categoriesApi.GetAllCategories();
            ViewData["loginError"] = loginError;
            ViewData["registerError"] = registerError;
            return View(new IndexViewModel{
                Services = services,
                Categories = categories
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
