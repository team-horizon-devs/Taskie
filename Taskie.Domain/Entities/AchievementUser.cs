using System;

namespace Taskie.Domain.Entities
{
    public class AchievementUser : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int AchievementId { get; set; }
        public Achievement Achievement { get; set; }

    }
}
