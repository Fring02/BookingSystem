using System;
using Domain.Models.Booking;

namespace Domain.Dtos
{
    public class BookingRequestUpdateDto
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
    }
}