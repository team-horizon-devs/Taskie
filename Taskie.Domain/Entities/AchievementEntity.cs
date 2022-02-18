using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Entities
{
    public class AchievementEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public int Priority1 { get; set; }

        [Required]
        public int Priority2 { get; set; }

        [Required]
        public int Priority3 { get; set; }
    }
}
