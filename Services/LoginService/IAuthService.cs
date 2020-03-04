using Cooky.API.DTOs.AuthDTO;
using Cooky.API.DTOs.UserDTO;
using Cooky.API.Models;
using Cooky.Models;
using System.Threading.Tasks;

namespace Cooky.API.Services.LoginService
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetUserDTO>> Register(RegisterUserDTO register);
        Task<ServiceResponse<GetLoginDTO>> Login(LoginUserDTO login);
        Task<ServiceResponse<GetUserDTO>> ChangePassword(UpdateUserDTO login);
        Task<ServiceResponse<User>> GetUserByToken(string token);
    }
}
