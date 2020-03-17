using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Cooky.API.DTOs.ProductDTO
{
    public class AddProductDTO
    {
        [Required]
        public string Name { get; set; }
        public float OriginalPrice { get; set; } = 0.0f;
        [Ignore]
        public string UserId { get; set; }
    }
}
