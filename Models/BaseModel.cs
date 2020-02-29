using System;

namespace Cooky.API.Models
{
    public class BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
