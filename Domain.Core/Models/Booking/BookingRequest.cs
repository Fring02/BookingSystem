using System;

namespace Domain.Core.Models.Booking
{
    public class BookingRequest : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureService Service { get; set; }
        public DateTime LeftAt { get; set; }
        public TimeSpan BookingTime { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Info { get; set; }
    }
}