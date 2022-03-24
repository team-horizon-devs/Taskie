using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.Avatar
{
    class AvatarDtoCreate
    {
        [Required]
        public string Desciption { get; set; }
        public string Image { get; set; }
    }
}
