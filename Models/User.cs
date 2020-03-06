using Cooky.API.Models.Enum;
using System;

namespace Cooky.API.Models
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Gender Gender { get; set; } = Gender.Undefined;
        public DateTime? Birthday { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; } = 0;
        public double Latitude { get; set; } = 0;
    }
}
