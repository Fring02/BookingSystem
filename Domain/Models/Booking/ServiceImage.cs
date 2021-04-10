using System;

namespace Domain.Models.Booking
{
    public class ServiceImage
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureService Service { get; set; }
        public string Path { get; set; }
        public DateTime PublishedAt { get; set; } = DateTime.Now;
    }
}