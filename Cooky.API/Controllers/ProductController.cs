using Cooky.API.Controllers.Base;
using Cooky.API.DTOs.ProductDTO;
using Cooky.API.Repositories.UserRepository;
using Cooky.API.Services.ProductService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cooky.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : BaseController
    {
        private readonly IProductService _service;
        public ProductController(IProductService service, IUserRepository userRepository) : base(userRepository)
        {
            this._service = service;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductDTO product)
        {
            return Ok(await _service.AddProduct(product, this.CurrentUser));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var response = await _service.GetProduct(id);
            if (response.Data == null)
            {
                response.Success = false;
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpGet("Nearby")]
        public async Task<IActionResult> Nearby(GetNearByDTO location)
        {
            return Ok(await _service.GetNearbyProducts(location));
        }
    }
}
