using System;
using System.ComponentModel.DataAnnotations;
using Domain.Models.Booking;

namespace Domain.Dtos
{
    public class BookingRequestCreateDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter service id")]
        public Guid ServiceId { get; set; }
        public DateTime LeftAt { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Enter booking time")]
        public TimeSpan BookingTime { get; set; }
        [Required(ErrorMessage = "Enter user id")]
        public Guid UserId { get; set; }
    }
}