using System;

namespace Domain.Dtos
{
    public class ServiceImageDto
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureServiceDto Service { get; set; }
    }
}