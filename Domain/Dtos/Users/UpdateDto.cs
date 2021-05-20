using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Users
{
    public class UpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
