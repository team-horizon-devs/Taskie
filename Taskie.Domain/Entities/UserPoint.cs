

namespace Taskie.Domain.Entities
{
    class UserPoint : BaseEntity
    {
        public string UserId { get; set; }
        public int Points { get; set; }

        public User User { get; set; }


    }
}
