using System;

namespace Taskie.Domain.Entities
{
    public class UserPoint : BaseEntity
    {
        public string UserId { get; set; }
        public int Points { get; set; }
        public User User { get; set; }
    }
}
