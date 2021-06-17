using System;
using System.Collections.Generic;
using Domain.Core.Helpers;
using Domain.Core.Models.Booking;

namespace Domain.Core.Models.Users
{
    public class User : IEntity<Guid>, IUser
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Role { get; set; } = Roles.USER;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public List<Order> BookingRequests { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
