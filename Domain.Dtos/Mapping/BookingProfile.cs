using AutoMapper;
using Domain.Core.Models.Booking;
using Domain.Dtos;
using Domain.Dtos.Booking;
using Domain.Dtos.Users;

namespace Domain.Mapping
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<LeisureService, LeisureServiceCreateDto>().ReverseMap();
            CreateMap<LeisureService, LeisureServiceViewDto>().ReverseMap();
            CreateMap<LeisureService, LeisureServiceUpdateDto>().ReverseMap();
            CreateMap<ServiceImage, ServiceImageViewDto>().ReverseMap();
            CreateMap<ServiceImage, ServiceImageCreateDto>().ReverseMap();
            CreateMap<BookingRequest, BookingRequestViewDto>().ReverseMap();
            CreateMap<BookingRequest, BookingRequestCreateDto>().ReverseMap();
            CreateMap<BookingRequest, BookingRequestUpdateDto>().ReverseMap();
            CreateMap<LeisureServiceCategory, LeisureServiceCategoryCreateDto>().ReverseMap();
            CreateMap<LeisureServiceCategory, LeisureServiceCategoryUpdateDto>().ReverseMap();
            CreateMap<LeisureServiceCategory, LeisureServiceCategoryViewDto>().ReverseMap();
            CreateMap<User, UserViewDto>().ReverseMap();
            CreateMap<RegisterUserDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
        }
    }
}