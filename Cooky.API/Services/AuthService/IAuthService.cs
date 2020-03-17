using Cooky.API.DTOs.AuthDTO;
using Cooky.API.DTOs.UserDTO;
using Cooky.Models;
using System.Threading.Tasks;

namespace Cooky.API.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<GetLoginDTO>> Register(RegisterUserDTO register);
        Task<ServiceResponse<GetLoginDTO>> Login(LoginUserDTO login);
        Task<ServiceResponse<GetUserDTO>> ChangePassword(UpdateUserDTO login);
    }
}
