using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cooky.API.Models
{
    public class Login : BaseModel
    {
        [Required]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [MaxLength(24)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
