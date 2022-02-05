using System;

namespace Taskie.Domain.Entities
{
    public class TrophyUserEntity
    {
        public string UserId { get; set; }
        public int TrophyId { get; set; }
        public TrophyEntity Tropy { get; set; }
        public UserEntity User { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
        public DateTime? UpdatedAt { get; set; }
    }
}
