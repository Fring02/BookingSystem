using System;

namespace Domain.Dtos.Booking
{
    public class BookingRequestViewDto
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureServiceViewDto Service { get; set; }
        public Guid UserId { get; set; }
        public DateTime LeftAt { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string Info { get; set; }
    }
}