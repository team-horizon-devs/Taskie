using System;
using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.Trophy
{
    public class TrophyUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Insira um nome para representar o Troféu")]
        [MaxLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insira uma descrição para representar o Troféu")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Insira uma imagem para representar o Troféu")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Insira o custo de pontos para comprar o Troféu")]
        public int PricePoints { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));

    }
}
