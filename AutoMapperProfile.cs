using AutoMapper;
using Cooky.API.DTOs.User;
using Cooky.API.Models;

namespace Cooky
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();
            CreateMap<User, GetUserDTO>();
        }
    }
}