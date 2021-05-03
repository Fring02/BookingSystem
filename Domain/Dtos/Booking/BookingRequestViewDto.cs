using System;
using Domain.Models.Booking;

namespace Domain.Dtos
{
    public class BookingRequestViewDto
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureServiceViewDto Service { get; set; }
        public DateTime LeftAt { get; set; }
        public TimeSpan BookingTime { get; set; }
    }
}