using AutoMapper;
using Cooky.API.DTOs.AuthDTO;
using Cooky.API.DTOs.UserDTO;
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
            CreateMap<RegisterUserDTO, User>();
        }
    }
}