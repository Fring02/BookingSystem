using Domain.Helpers;
using Domain.Interfaces.Models;
using Domain.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Users
{
   public class Owner : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<LeisureService> Services { get; set; }
    }
}
