using System.Threading.Tasks;
using Cooky.API.DTOs.UserDTO;
using Cooky.Models;

namespace Cooky.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDTO>> GetUserById(string id);
        Task<ServiceResponse<GetUserDTO>> UpdateUser(UpdateUserDTO updateUser);
        Task<ServiceResponse<bool>> DeleteUser(string id);
    }
}