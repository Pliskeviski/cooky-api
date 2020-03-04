using System;
using System.Threading.Tasks;
using AutoMapper;
using Cooky.API.DTOs.UserDTO;
using Cooky.API.Models;
using Cooky.API.Repositories.UserRepository;
using Cooky.Models;

namespace Cooky.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this._mapper = mapper;
            this._repository = userRepository;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(string id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            try
            {
                serviceResponse.Data = _mapper.Map<GetUserDTO>(await _repository.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updatedUser)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                User user = await _repository.GetByIdAsync(updatedUser.Id);
                if(user == null)
                    return serviceResponse;

                // TODO: Check permission
                user.Birthday = updatedUser.Birthday == null ? user.Birthday : updatedUser.Birthday;
                user.Description = updatedUser.Description == null ? user.Description : updatedUser.Description;
                user.Gender = updatedUser.Gender == null ? user.Gender : updatedUser.Gender.Value;
                user.Name = updatedUser.Name == null ? user.Name : updatedUser.Name;
                user.Picture = updatedUser.Picture == null ? user.Picture : updatedUser.Picture;

                await _repository.Update(user);
                
                serviceResponse.Data = _mapper.Map<GetUserDTO>(await _repository.GetByIdAsync(user.Id));
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteUser(string id)
        {
            var serviceResponse = new ServiceResponse<bool>() { Data = false };

            try
            {
                // TODO: Check permission
                await _repository.Delete(id);
                serviceResponse.Data = true;
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