using AutoMapper;
using Domain.Core.Models.Booking;
using Domain.Core.Models.Users;
using Domain.Dtos.Booking;
using Domain.Dtos.Users;

namespace Infrastructure.Services.Mapping
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
            CreateMap<Order, BookingRequestViewDto>().ReverseMap();
            CreateMap<Order, BookingRequestCreateDto>().ReverseMap();
            CreateMap<Order, BookingRequestUpdateDto>().ReverseMap();
            CreateMap<Category, LeisureServiceCategoryCreateDto>().ReverseMap();
            CreateMap<Category, LeisureServiceCategoryUpdateDto>().ReverseMap();
            CreateMap<Category, LeisureServiceCategoryViewDto>().ReverseMap();
            CreateMap<Comment, CommentViewDto>().ReverseMap();
            CreateMap<Comment, CommentCreateDto>().ReverseMap();
            CreateMap<Comment, CommentUpdateDto>().ReverseMap();
            CreateMap<User, UserViewDto>().ReverseMap();
            CreateMap<RegisterUserDto, User>().ReverseMap();
            CreateMap<UserUpdateDto, User>().ReverseMap();
        }
    }
}