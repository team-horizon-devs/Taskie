using System;

namespace Taskie.Domain.Entities
{
    class UserPoint
    {
        public string UserId { get; set; }
        public int Points { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
