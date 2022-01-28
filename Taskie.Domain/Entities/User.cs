using Microsoft.AspNetCore.Identity;
using System;

namespace Taskie.Domain.Entities
{
    class User : IdentityUser
    {
        public bool Active { get; set; }
        public DateTime LastLogin { get; set; }
        public int AvatarId { get; set; }
        public Avatar Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
