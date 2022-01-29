using Microsoft.AspNetCore.Identity;
using System;

namespace Taskie.Domain.Entities
{
    public class User : IdentityUser
    {
        public bool Active { get; set; } = true;
        public DateTime LastLogin { get; set; }
        public int AvatarId { get; set; }
        public Avatar Avatar { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

    }
}
