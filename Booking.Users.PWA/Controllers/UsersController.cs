using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Booking.Users.PWA.Apis.Interfaces;
using Booking.Users.PWA.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Users.PWA.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersApi _usersApi;

        public UsersController(IUsersApi usersApi)
        {
            _usersApi = usersApi;
        }
        public async Task<IActionResult> LoginUserAsync(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { loginError = "Fill all fields" });
            }
            string responseString = await _usersApi.LoginResponseAsync(user);
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var claims = handler.ReadJwtToken(responseString).Claims;
                string id = claims.First(claim => claim.Type == "nameid").Value;
                if (!string.IsNullOrEmpty(id)) HttpContext.Session.SetString("id", id);
                HttpContext.Session.SetString("token", responseString);
                return RedirectToAction("Index", "Home");
            } catch
            {
                if (responseString.Length < 50)
                    return RedirectToAction("Index", "Home", new { loginError = responseString });
                else throw;
            }
        }


        public async Task<IActionResult> RegisterUserAsync(RegisterViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { registerError = "Fill all fields" });
            }
            string responseString = await _usersApi.RegisterResponseAsync(user);
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var claims = handler.ReadJwtToken(responseString).Claims;
                string id = claims.First(claim => claim.Type == "nameid").Value;
                if (!string.IsNullOrEmpty(id)) HttpContext.Session.SetString("id", id);
                HttpContext.Session.SetString("token", responseString);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                if (responseString.Length < 50)
                    return RedirectToAction("Index", "Home", new { registerError = responseString });
                else throw;
            }
        }

        public async Task<IActionResult> UpdateUserAsync(UpdateUserViewModel user)
        {
            if (await _usersApi.UpdateUserAsync(user, HttpContext.Session.GetString("token")))
            {
                return RedirectToAction("ProfilePage", "Profile");
            } else
            {
                return RedirectToAction("ProfilePage", "Profile", new { updateError = "Failed to update" });
            }
        }
    }
}
