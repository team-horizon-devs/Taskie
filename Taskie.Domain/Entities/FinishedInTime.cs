using System;

namespace Taskie.Domain.Entities
{
    public class FinishedInTime : BaseEntity
    {
        public string UserId { get; set; }
        public int Priority1 { get; set; }
        public int Priority2 { get; set; }
        public int Priority3 { get; set; }
        public User User { get; set; }
    }
}
