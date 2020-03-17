using Cooky.API.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Cooky.API.Models
{
    public class Product : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public float Price { get; set; } = 0.0f;
        public float OriginalPrice { get; set; } = 0.0f;
        public ProductStatus Status { get; set; } = ProductStatus.Removed;
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
