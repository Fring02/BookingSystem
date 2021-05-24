using System;

namespace Booking.Users.PWA.ViewModels
{
    public class BookingRequestViewModel
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureServiceViewModel Service { get; set; }
        public DateTime LeftAt { get; set; } = DateTime.Now;
        public TimeSpan BookingTime { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public Guid UserId { get; set; }
        public string Info { get; set; }
    }
}