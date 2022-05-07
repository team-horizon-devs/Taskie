using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.TrophyUser
{
    public class TrophyUserCreateDto
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int TrophyId { get; set; }
    }
}
