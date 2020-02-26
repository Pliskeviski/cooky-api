using AutoMapper;
using webapi_learning.DTOs.Character;
using webapi_learning.Models;

namespace webapi_learning
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDTO>();
            CreateMap<AddCharacterDTO, Character>();
            CreateMap<UpdateCharacterDTO, Character>();
        }
    }
}