using System;

namespace Domain.Models.Booking
{
    public class ServiceImage
    {
        public Guid Id { get; set; }
        public Guid ServiceId { get; set; }
        public LeisureService Service { get; set; }
    }
}