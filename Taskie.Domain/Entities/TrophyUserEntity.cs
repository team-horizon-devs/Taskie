using System;
using System.Collections.Generic;

namespace Taskie.Domain.Entities
{
    public class TrophyUserEntity
    {
        public string UserId { get; set; }
        public int TrophyId { get; set; }
        public TrophyEntity Trophy { get; set; }
        public UserEntity User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
        public DateTime? UpdatedAt { get; set; } = null;
    }
}
