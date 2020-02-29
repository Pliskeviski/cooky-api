using Cooky.API.Models;
using System;

namespace Cooky.API.DTOs.UserDTO
{
    public class GetUserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public double? Logitude { get; set; }
        public double? Latitude { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
