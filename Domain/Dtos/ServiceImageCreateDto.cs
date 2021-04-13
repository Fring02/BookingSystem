using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class ServiceImageCreateDto
    {
        public Guid Id { get; set; }
        [Required]
        public Guid ServiceId { get; set; }
        [Required]
        public string Path { get; set; }
        public LeisureServiceCreateDto Service { get; set; }
    }
}