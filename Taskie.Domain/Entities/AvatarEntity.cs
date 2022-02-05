using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Entities
{
    public class AvatarEntity : BaseEntity
    {
        public string Desciption { get; set; }

        [Required]
        public string Src { get; set; }
    }
}
