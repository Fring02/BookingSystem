using System;
using System.Collections.Generic;

namespace Domain.Models.Booking
{
    public class LeisureService
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public List<ServiceImage> Images { get; set; }
        public DateTime BookingTime { get; set; }
        public TimeSpan BookingDuration { get; set; }
    }
}