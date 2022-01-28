using System;

namespace Taskie.Domain.Entities
{
    public class TrophyUser
    {
        public string UserId { get; set; }
        public int TrophyId { get; set; }
        public Trophy Trophy { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
