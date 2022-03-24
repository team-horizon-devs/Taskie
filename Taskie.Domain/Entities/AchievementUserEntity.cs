using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taskie.Domain.Entities
{
    public class AchievementUserEntity
    {
        public string UserId { get; set; }
        public UserEntity User { get; set; }

        public int AchievementId { get; set; }

        public AchievementEntity Achievement { get; set; }
<<<<<<< HEAD
        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
        public DateTime? UpdatedAt { get; set; }
=======

        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));

        public DateTime? UpdatedAt { get; set; } = null;
>>>>>>> develop

    }
}
