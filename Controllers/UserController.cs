using Cooky.API.DTOs.UserDTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cooky.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Cooky.API.Controllers.Base;
using Cooky.API.Repositories.UserRepository;

namespace Cooky.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
    }
}
