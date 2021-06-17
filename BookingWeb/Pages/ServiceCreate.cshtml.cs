using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingWeb.Pages
{
    public class ServiceCreateModel : PageModel
    {
        public void OnGet()
        {
            //This is for saving user details to show on other pages
            ViewData["user"] = HttpContext.Session.GetString("user");
        }
    }
}
