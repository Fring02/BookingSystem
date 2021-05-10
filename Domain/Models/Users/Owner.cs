using Domain.Helpers;
using Domain.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Users
{
   public class Owner
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public string Role { get => Roles.OWNER; }
        public List<LeisureService> Services { get; set; }
    }
}
