using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Booking
{
    public class LeisureServiceCreateDto
    {
        [Required(ErrorMessage = "Enter leisure service name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter leisure service location")]
        public string Location { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Enter leisure service description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter leisure service working time")]
        [RegularExpression("^([01]?[0-9]|2[0-3]):[0-5][0-9]-([01]?[0-9]|2[0-3]):[0-5][0-9]$",
            ErrorMessage = "Enter working time in working time format: 00:00-23:59")]
        public string WorkingTime { get; set; }
        [Required(ErrorMessage = "Enter category id")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Enter owner id")]
        public Guid OwnerId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}