using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookingWeb.Pages
{
    public class ServiceCreateModel : PageModel
    {

        private readonly IOwnersApi _ownersApi;
        private readonly IServicesApi _servicesApi;
        private readonly ICategoriesApi _categoriesApi;

        public ServiceCreateModel(IServicesApi servicesApi, IOwnersApi ownersApi, ICategoriesApi categoriesApi)
        {
            _servicesApi = servicesApi;
            _ownersApi = ownersApi;
            _categoriesApi = categoriesApi;
        }

        [BindProperty]
        public LeisureServiceCreateView ServiceForm { get; set; }
        [BindProperty]
        public IEnumerable<LeisureServiceCategoryViewModel> CategoriesList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                var cat = await _categoriesApi.GetAllCategories();
                CategoriesList = cat;

                ViewData["owner"] = Guid.Parse(HttpContext.Session.GetString("id"));
            }
            else
            {
                return RedirectToPage("Login");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostCreateServiceAsync()
        {
            var cat = await _categoriesApi.GetAllCategories();
            CategoriesList = cat;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("id")))
            {
                Guid id = Guid.Parse(HttpContext.Session.GetString("id"));

                if (id != Guid.Empty)
                {
                    string token = HttpContext.Session.GetString("token");

                    if (await _servicesApi.CreateService(ServiceForm, token))
                    {
                        return RedirectToPage("/Service");
                    }

                }
            }

            ViewData["Err"] = "Some errors happened! Please, try later";
            return Page();
        }
    }
}
