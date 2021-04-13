using Domain.Models.Users;
using System;

namespace Domain.Models.Booking
{
    public class BookingRequest
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureService Service { get; set; }
        public DateTime LeftAt { get; set; }
        public TimeSpan BookingTime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}