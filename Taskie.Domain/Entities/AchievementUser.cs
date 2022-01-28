using System;

namespace Taskie.Domain.Entities
{
    public class AchievementUser
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int AchievementsId { get; set; }
        public Achievement Achievement { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
