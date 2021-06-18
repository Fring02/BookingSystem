using System;
using System.ComponentModel.DataAnnotations;

namespace BookingWeb.Models
{
    public class LeisureServiceCreateView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public string Website { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [RegularExpression("^([01]?[0-9]|2[0-3]):[0-5][0-9]-([01]?[0-9]|2[0-3]):[0-5][0-9]$",
            ErrorMessage = "Enter working time in working time format: 00:00-23:59")]
        public string WorkingTime { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}
