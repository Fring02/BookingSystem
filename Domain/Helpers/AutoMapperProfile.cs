using AutoMapper;
using Domain.Dtos.Users;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<UpdateDto, User>();
        }
    }
}
