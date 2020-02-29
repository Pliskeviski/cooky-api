using System;

namespace Cooky.API.Models
{
    public class BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedAt { get; set; }
    }
}
