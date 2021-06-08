using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingWeb.Pages
{
    public class LoginModel : PageModel
    {

        public LoginDTO LoginForm { get; set; }

        public void OnGet()
        {
        }
    }
}
