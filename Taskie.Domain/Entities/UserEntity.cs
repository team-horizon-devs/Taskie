using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public int AvatarId { get; set; } = 1;
        public AvatarEntity Avatar { get; set; }
        public int Point { get; set; } = 0;
        public IEnumerable<TrophyUserEntity> TrophiesUser { get; set; }
        public IEnumerable<AchievementUserEntity> AchievementsUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
        public DateTime? UpdatedAt { get; set; } = null;

    }
}
