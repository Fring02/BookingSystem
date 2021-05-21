using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Users.PWA.Apis.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Users.PWA.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUsersApi _usersApi;

        public ProfileController(IUsersApi usersApi)
        {
            _usersApi = usersApi;
        }
        [HttpGet("/profile")]
        public async Task<IActionResult> ProfilePageAsync()
        {
            Guid id = Guid.Parse(HttpContext.Session.GetString("id"));
            string token = HttpContext.Session.GetString("token");
            var user = await _usersApi.GetUserByIdAsync(id, token);
            return View(user);
        }



        public IActionResult SignoutAsync()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
