using AutoMapper;
using Cooky.API.DTOs.AuthDTO;
using Cooky.API.DTOs.ProductDTO;
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
            CreateMap<RegisterUserDTO, User>();
            CreateMap<User, GetUserDTO>()
                .ForMember(x => x.Products, opt => opt.MapFrom(s => s.Products));

            CreateMap<AddProductDTO, Product>();
            CreateMap<Product, GetProductDTO>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(s => s.User.Name));
        }
    }
}