using Cooky.API.Models;
namespace Cooky.API.DTOs.LoginDTO
{
    public class GetLoginDTO
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
    }
}
