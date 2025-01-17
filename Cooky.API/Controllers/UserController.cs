﻿using Cooky.API.DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cooky.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Cooky.API.Controllers.Base;
using Cooky.API.Repositories.UserRepository;
using Cooky.API.DTOs.ProductDTO;

namespace Cooky.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService _service;
        public UserController(IUserService userService, IUserRepository userRepository) : base(userRepository)
        {
            this._service = userService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var response = await _service.GetUserById(id);
            if (response.Data == null)
            {
                response.Success = false;
                return NotFound(response);
            }
            
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO user)
        {
            var response = await _service.UpdateUser(user);
            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return Ok(await _service.DeleteUser(id));
        }

        [Authorize]
        [HttpGet("Nearby")]
        public async Task<IActionResult> Nearby(double latitude, double longitude)
        {
            return Ok(await _service.GetNearbyUsers(new GetNearByDTO() { Latitude = latitude, Longitude = longitude }));
        }
    }
}
