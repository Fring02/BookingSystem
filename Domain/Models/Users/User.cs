using Domain.Helpers;
using Domain.Interfaces.Models;
using Domain.Models.Booking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.Users
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<BookingRequest> BookingRequests { get; set; }
    }
}
