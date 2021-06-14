using System;
using System.Collections.Generic;

namespace Domain.Core.Models.Booking
{
    public class User : IEntity<Guid>, IUser
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
