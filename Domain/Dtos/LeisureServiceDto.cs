using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class LeisureServiceDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter leisure service name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter leisure service location")]
        public string Location { get; set; }
        public string Website { get; set; }
        public int Rating { get; set; }
        [Required(ErrorMessage = "Enter leisure service description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter leisure service working time")]
        public string WorkingTime { get; set; }
        public List<ServiceImageDto> Images { get; set; }
        public DateTime BookingTime { get; set; } = DateTime.Now;
        public TimeSpan BookingDuration { get; set; }
    }
}