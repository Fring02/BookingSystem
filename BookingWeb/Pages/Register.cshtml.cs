using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace BookingWeb.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IOwnersApi _usersApi;

        public RegisterModel(IOwnersApi usersApi)
        {
            _usersApi = usersApi ?? throw new ArgumentNullException(nameof(usersApi));
        }

        [BindProperty]
        public RegisterDTO RegisterForm { get; set; }

        [ViewData]
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostRegisterOwnerAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string registerTokenResponse = await _usersApi.RegisterOwnerAsync(RegisterForm);

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var claims = handler.ReadJwtToken(registerTokenResponse).Claims;
                string id = claims.First(claim => claim.Type == "nameid").Value;
                if (!string.IsNullOrEmpty(id)) HttpContext.Session.SetString("id", id);
                HttpContext.Session.SetString("token", registerTokenResponse);
                return RedirectToPage("Confirmation");
            }
            catch
            {
                if (registerTokenResponse.Length < 50)
                {
                    return Page();
                }
                else throw;
            }
        }
    }
}