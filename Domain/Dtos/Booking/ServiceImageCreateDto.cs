using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos
{
    public class ServiceImageCreateDto
    {
        [Required(ErrorMessage = "Specify service id for image")]
        public Guid ServiceId { get; set; }
        [Required(ErrorMessage = "Specify path url for image")]
        public string Path { get; set; }
    }
}