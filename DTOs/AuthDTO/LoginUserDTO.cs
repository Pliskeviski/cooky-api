using System.ComponentModel.DataAnnotations;

namespace Cooky.API.DTOs.AuthDTO
{
    public class LoginUserDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
