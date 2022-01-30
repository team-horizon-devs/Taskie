using System;

namespace Taskie.Domain.Entities
{
    public class TrophyUser : BaseEntity
    {
        public string UserId { get; set; }
        public int TrophyId { get; set; }
        public Trophy Trophy { get; set; }
        public User User { get; set; }
    }
}
