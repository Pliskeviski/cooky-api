using System.Collections.Generic;
using System.Threading.Tasks;
using webapi_learning.DTOs.Character;
using webapi_learning.Models;

namespace webapi_learning.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter);
        Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacter);
        Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id);
    }
}