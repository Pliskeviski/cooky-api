using System.ComponentModel.DataAnnotations;

namespace Cooky.API.DTOs.AuthDTO
{
    public class RegisterUserDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
