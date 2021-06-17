using System;

namespace Domain.Dtos
{
    public class ServiceImageViewDto
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureServiceViewDto Service { get; set; }
        public string Path { get; set; }
    }
}