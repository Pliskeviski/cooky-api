using Cooky.API.DTOs.User;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cooky.Models;

namespace Cooky.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDTO>> GetUserById(string id);
        Task<ServiceResponse<GetUserDTO>> AddUser(AddUserDTO newCharacter);
        Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updateCharacter);
        Task<ServiceResponse<bool>> DeleteUser(string id);
    }
}