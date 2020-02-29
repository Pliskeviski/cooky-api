using Cooky.API.DTOs.LoginDTO;
using Cooky.API.Services.LoginService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cooky.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService userService)
        {
            this._service = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterLoginDTO login)
        {
            return Ok(await _service.Register(login));
        }
    }
}
