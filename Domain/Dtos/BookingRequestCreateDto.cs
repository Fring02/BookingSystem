using System;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Booking;

namespace Domain.Dtos
{
    public class BookingRequestCreateDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ServiceId { get; set; }
        public LeisureService Service { get; set; }
        public DateTime LeftAt { get; set; } = DateTime.Now;
        [Required]
        public TimeSpan BookingTime { get; set; }
    }
}