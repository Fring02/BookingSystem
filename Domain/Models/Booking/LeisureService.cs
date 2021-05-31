﻿using Domain.Interfaces.Models;
using Domain.Models.Users;
using System;
using System.Collections.Generic;

namespace Domain.Models.Booking
{
    public class LeisureService : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public double Rating { get; set; }
        public int RatedCount { get; set; }
        public string Description { get; set; }
        public string WorkingTime { get; set; }
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
        public Guid CategoryId { get; set; }
        public LeisureServiceCategory Category { get; set; }
        public List<ServiceImage> Images { get; set; }
        public List<BookingRequest> BookingRequests { get; set; }
    }
}