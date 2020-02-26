using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_learning.DTOs.Character;
using webapi_learning.Models;
using webapi_learning.Repositories;

namespace webapi_learning.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly ICharacterRepository _characterRepository;
        public CharacterService(IMapper mapper, ICharacterRepository characterRepository)
        {
            this._mapper = mapper;
            this._characterRepository = characterRepository;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> AddCharacter(AddCharacterDTO newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();

            try
            {
                await _characterRepository.AddAsync(_mapper.Map<Character>(newCharacter));
                
                var characters = await _characterRepository.GetAllAsync();
                serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();

            try
            {
                var characters = await _characterRepository.GetAllAsync();
                serviceResponse.Data = characters.Select(x => _mapper.Map<GetCharacterDTO>(x)).ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();
            try
            {
                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(await _characterRepository.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDTO>> UpdateCharacter(UpdateCharacterDTO updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDTO>();

            try
            {
                await _characterRepository.Update(_mapper.Map<Character>(updateCharacter));

                serviceResponse.Data = _mapper.Map<GetCharacterDTO>(await _characterRepository.GetByIdAsync(updateCharacter.Id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDTO>>> DeleteCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDTO>>();

            try
            {
                var character = await _characterRepository.GetByIdAsync(id);
                _characterRepository.Remove(character);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}