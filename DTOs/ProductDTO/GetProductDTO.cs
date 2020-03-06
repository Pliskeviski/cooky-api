using Cooky.API.Models;
using Cooky.API.Models.Enum;

namespace Cooky.API.DTOs.ProductDTO
{
    public class GetProductDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float OriginalPrice { get; set; }
        public ProductStatus Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
