using System;

namespace Taskie.Domain.Entities
{
    public class AchievementUserEntity
    {
        public string UserId { get; set; }
        public UserEntity User { get; set; }
        public int AchievementId { get; set; }
        public AchievementEntity Achievement { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

    }
}
