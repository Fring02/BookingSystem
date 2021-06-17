using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingWeb.Pages
{
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
            ViewData["user"] = HttpContext.Session.GetString("user");
        }
    }
}
