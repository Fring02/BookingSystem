using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class LeisureServiceViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public List<ServiceImageDto> Images { get; set; }
        public DateTime BookingTime { get; set; } = DateTime.Now;
        public TimeSpan BookingDuration { get; set; }
    }
}