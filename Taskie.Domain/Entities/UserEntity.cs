using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Entities
{
    public class UserEntity : IdentityUser
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public int AvatarId { get; set; }
        public AvatarEntity Avatar { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

    }
}
