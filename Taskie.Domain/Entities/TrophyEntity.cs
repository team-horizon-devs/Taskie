using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Entities
{
    public class TrophyEntity : BaseEntity

    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int PricePoints { get; set; }
    }
}
