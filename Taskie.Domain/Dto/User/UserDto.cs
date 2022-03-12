using System;
using System.Collections.Generic;
using Taskie.Domain.Dto.AchievementUser;
using Taskie.Domain.Dto.Avatar;
using Taskie.Domain.Dto.Trophy;
using Taskie.Domain.Dto.TrophyUser;

namespace Taskie.Domain.Dto.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Point { get; set; }
        public IEnumerable<AchievementUserToUserDto> AchievementsUser { get; set; }
        public IEnumerable<TrophyUserToUserDto> TrophiesUser { get; set; }
        public AvatarToUserDto Avatar { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
