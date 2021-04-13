using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class LeisureServiceUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public DateTime BookingTime { get; set; }
    }
}