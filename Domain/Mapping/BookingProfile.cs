using AutoMapper;
using Domain.Dtos;
using Domain.Models.Booking;

namespace Domain.Mapping
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<LeisureService, LeisureServiceDto>().ReverseMap();
            CreateMap<ServiceImage, ServiceImageDto>().ReverseMap();
        }
    }
}