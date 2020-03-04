using AutoMapper;
using Cooky.API.DTOs.AuthDTO;
using Cooky.API.DTOs.UserDTO;
using Cooky.API.Models;
using Cooky.API.Repositories.UserRepository;
using Cooky.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Cooky.API.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly IConfiguration _config;
        public AuthService(IMapper mapper, IUserRepository userRepository, IConfiguration config)
        {
            this._mapper = mapper;
            this._repository = userRepository;
            this._config = config;
        }

        public async Task<ServiceResponse<GetUserDTO>> ChangePassword(UpdateUserDTO updateCharacter)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetUserByToken(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetLoginDTO>> Login(LoginUserDTO login)
        {
            var serviceResponse = new ServiceResponse<GetLoginDTO>();

            try
            {
                var user = await _repository.SingleOrDefaultAsync(x => x.Email == login.Email);

                if (user == null)
                    return null;

                if (!VerifyPassword(login.Password, user.PasswordHash, user.PasswordSalt))
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config.GetSection("Token").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                serviceResponse.Data = new GetLoginDTO() { Token = tokenString };
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> Register(RegisterUserDTO register)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                User user = _mapper.Map<User>(register);

                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(register.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _repository.AddAsync(user);

                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}
