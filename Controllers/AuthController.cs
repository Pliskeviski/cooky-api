using System.Threading.Tasks;
using Cooky.API.DTOs.AuthDTO;
using Cooky.API.Services.LoginService;
using Microsoft.AspNetCore.Mvc;

namespace Cooky.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        public AuthController(IAuthService service)
        {
            this._service = service;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDTO login)
        {
            return Ok(await _service.Register(login));
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO login)
        {
            return Ok(await _service.Login(login));
        }
    }
}
