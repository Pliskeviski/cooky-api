﻿using Cooky.API.Models;
using Cooky.API.Models.Enum;
using System;

namespace Cooky.API.DTOs.UserDTO
{
    public class UpdateUserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Gender? Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
    }
}
