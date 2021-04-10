using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class LeisureServiceCreateDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter leisure service name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter leisure service location")]
        public string Location { get; set; }
        public string Website { get; set; }
        [Required(ErrorMessage = "Enter leisure service description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter leisure service working time")]
        //TODO(Write regex for working time format)
        [RegularExpression("^([01]?[0-9]|2[0-3]):[0-5][0-9]-([01]?[0-9]|2[0-3]):[0-5][0-9]$",
            ErrorMessage = "Enter working time in working time format: 00:00-24:59")]
        public string WorkingTime { get; set; }
    }
}