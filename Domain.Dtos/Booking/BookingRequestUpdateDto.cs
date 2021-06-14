using System;
namespace Domain.Dtos.Booking
{
    public class BookingRequestUpdateDto
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public TimeSpan BookingTime { get; set; }
        public string Info { get; set; }
    }
}