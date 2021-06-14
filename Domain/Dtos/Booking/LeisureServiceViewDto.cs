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
        public int RatedCount { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public List<ServiceImageViewDto> Images { get; set; }
        public DateTime BookingTime { get; set; }
        public Guid CategoryId { get; set; }
        public LeisureServiceCategoryViewDto Category { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}