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
    public class RegisterModel : PageModel
    {
        private readonly IUsersApi _usersApi;

        public RegisterModel(IUsersApi usersApi)
        {
            _usersApi = usersApi ?? throw new ArgumentNullException(nameof(usersApi));
        }

        [BindProperty]
        public RegisterDTO RegisterForm { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegisterOwnerAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _usersApi.RegisterOwner(RegisterForm);
            return RedirectToPage("Profile");
        }
    }
}
