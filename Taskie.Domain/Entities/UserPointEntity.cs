using System;

namespace Taskie.Domain.Entities
{
    public class UserPointEntity
    {
        public string UserId { get; set; }
        public int Points { get; set; }
        public UserEntity User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
