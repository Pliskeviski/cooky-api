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
    [Route("[controller]")]
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
    }
}
