using BookingWeb.ApiCollection.Interfaces;
using BookingWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace BookingWeb.Pages
{
    public class LoginModel : PageModel
    {

        private readonly IOwnersApi _ownersApi;

        public LoginModel(IOwnersApi ownersApi)
        {
            _ownersApi = ownersApi ?? throw new ArgumentNullException(nameof(ownersApi));
        }

        [BindProperty]
        public LoginDTO LoginForm { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginOwnerAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            string loginTokenResponse = await _ownersApi.LoginOwnerAsync(LoginForm);

            try
            {
                var handler = new JwtSecurityTokenHandler();
                var claims = handler.ReadJwtToken(loginTokenResponse).Claims;
                string id = claims.First(claim => claim.Type == "nameid").Value;
                if (!string.IsNullOrEmpty(id)) HttpContext.Session.SetString("id", id);
                HttpContext.Session.SetString("token", loginTokenResponse);
                return RedirectToPage("Profile");
            }
            catch
            {
                if (loginTokenResponse.Length < 50)
                {
                    ViewData["message"] = loginTokenResponse;
                    return Page();
                }
                else throw;
            }
        }
    }
}
