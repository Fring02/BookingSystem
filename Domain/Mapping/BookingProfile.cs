using AutoMapper;
using Domain.Dtos;
using Domain.Models.Booking;

namespace Domain.Mapping
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<LeisureService, LeisureServiceCreateDto>().ReverseMap();
            CreateMap<LeisureService, LeisureServiceViewDto>().ReverseMap();
            CreateMap<LeisureService, LeisureServiceUpdateDto>().ReverseMap();
            CreateMap<ServiceImage, ServiceImageDto>().ReverseMap();
            CreateMap<ServiceImage, ServiceImageCreateDto>().ReverseMap();
            CreateMap<BookingRequest, BookingRequestViewDto>().ReverseMap();
            CreateMap<BookingRequest, BookingRequestCreateDto>().ReverseMap();
            CreateMap<BookingRequest, BookingRequestUpdateDto>().ReverseMap();
            CreateMap<LeisureServiceCategory, LeisureServiceCategoryCreateDto>().ReverseMap();
            CreateMap<LeisureServiceCategory, LeisureServiceCategoryUpdateDto>().ReverseMap();
            CreateMap<LeisureServiceCategory, LeisureServiceCategoryViewDto>().ReverseMap();
        }
    }
}