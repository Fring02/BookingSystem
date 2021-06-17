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
    public class ProfileModel : PageModel
    {
        private readonly IOwnersApi _ownersApi;

        public ProfileModel(IOwnersApi ownersApi)
        {
            _ownersApi = ownersApi;
        }

        [BindProperty]
        public OwnerProfileModel ownerProfileModel { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("id")))
            {
                Guid id = Guid.Parse(HttpContext.Session.GetString("id"));

                if (id != Guid.Empty)
                {
                    string token = HttpContext.Session.GetString("token");

                    //TODO: Delete before final release
                    ownerProfileModel = await _ownersApi.GetOwnerByIdAsync(id, token);
                }
            }
            else
            {
                return RedirectToPage("Login");
            }
            
            return Page();
        }

        public class PasswordSet
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("Index");
        }

    }
}
