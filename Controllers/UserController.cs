using Cooky.API.DTOs.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cooky.Services.UserService;

namespace Cooky.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)
        {
            this._service = userService;
        }

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

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDTO user)
        {
            return Ok(await _service.AddUser(user));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO user)
        {
            var response = await _service.UpdateUser(user);
            if (response.Data == null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return Ok(await _service.DeleteUser(id));
        }
    }
}
