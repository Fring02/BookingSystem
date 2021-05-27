using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingWeb.Pages
{
    public class ProfileModel : PageModel
    {

        [BindProperty]
        public RegisterDTO RegisterForm { get; set; }

        public PasswordSet PasswordDTO { get; set; }

        public void OnGet()
        {
        }

        public class PasswordSet
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
        }
    }
}
