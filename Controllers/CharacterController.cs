using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_learning.DTOs.Character;
using webapi_learning.Models;
using webapi_learning.Services.CharacterService;

namespace webapi_learning.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost("AddCharacter")]
        public async Task<IActionResult> AddCharacter(AddCharacterDTO newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut("UpdateCharacter")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDTO updateCharacter)
        {
            var response = await _characterService.UpdateCharacter(updateCharacter);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}