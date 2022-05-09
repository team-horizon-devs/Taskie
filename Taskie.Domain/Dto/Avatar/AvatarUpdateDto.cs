using System;
using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.Avatar
{
    public class AvatarUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira uma descrição para representar o Avatar")]
        public string Desciption { get; set; }

        [Required(ErrorMessage = "Insira uma imagem para representar o Avatar")]
        public string Image { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
