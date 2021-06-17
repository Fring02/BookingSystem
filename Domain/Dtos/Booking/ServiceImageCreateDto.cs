using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class ServiceImageCreateDto
    {
        [Required]
        public Guid ServiceId { get; set; }
        [Required]
        public string Path { get; set; }
        public LeisureServiceCreateDto Service { get; set; }
    }
}