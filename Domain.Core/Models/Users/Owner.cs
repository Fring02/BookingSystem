using System;
using System.Collections.Generic;

namespace Domain.Core.Models.Booking
{
   public class Owner : IEntity<Guid>, IUser
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
