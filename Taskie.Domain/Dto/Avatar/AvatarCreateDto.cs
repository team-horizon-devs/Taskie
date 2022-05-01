using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.Avatar
{
    public class AvatarCreateDto
    {
        [Required]
        public string Desciption { get; set; }
        public string Image { get; set; }
    }
}
