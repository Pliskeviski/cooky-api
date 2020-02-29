using Cooky.API.DTOs.LoginDTO;
using Cooky.API.DTOs.UserDTO;
using Cooky.Models;
using System.Threading.Tasks;

namespace Cooky.API.Services.LoginService
{
    public interface ILoginService
    {
        Task<ServiceResponse<GetLoginDTO>> Register(RegisterLoginDTO register);
        Task<ServiceResponse<GetLoginDTO>> Login(AddUserDTO login);
        Task<ServiceResponse<GetLoginDTO>> ChangePassword(UpdateUserDTO updateCharacter);
        Task<ServiceResponse<bool>> DeleteLogin(string id);
    }
}
