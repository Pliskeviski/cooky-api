using AutoMapper;
using Cooky.API.DTOs.LoginDTO;
using Cooky.API.DTOs.UserDTO;
using Cooky.API.Models;
using Cooky.API.Repositories.LoginRepository;
using Cooky.Models;
using System;
using System.Threading.Tasks;

namespace Cooky.API.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IMapper _mapper;
        private readonly ILoginRepository _repository;
        public LoginService(IMapper mapper, ILoginRepository loginRepository)
        {
            this._mapper = mapper;
            this._repository = loginRepository;
        }
        public async Task<ServiceResponse<GetLoginDTO>> ChangePassword(UpdateUserDTO updateCharacter)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> DeleteLogin(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetLoginDTO>> Login(AddUserDTO login)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetLoginDTO>> Register(RegisterLoginDTO register)
        {
            var serviceResponse = new ServiceResponse<GetLoginDTO>();

            try
            {
                Login login = _mapper.Map<Login>(register);

                User user = new User();
                login.UserId = user.Id;
                login.User = user;

                await _repository.AddAsync(login);

                serviceResponse.Data = _mapper.Map<GetLoginDTO>(login);
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
