using System;
using System.ComponentModel.DataAnnotations;

namespace Taskie.Domain.Dto.Achievement
{
    public class AchievementCreateDto
    {
        [Required(ErrorMessage = "Insira uma nome para representar a recompensa")]
        [MaxLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Insira uma descrição para representar a recompensa")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Insira uma imagem para representar a recompensa")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Insira a quatidade de tarefas de prioridade 1 necessária para obter a conquista")]
        public int Priority1 { get; set; }

        [Required(ErrorMessage = "Insira a quatidade de tarefas de prioridade 2 necessária para obter a conquista")]
        public int Priority2 { get; set; }

        [Required(ErrorMessage = "Insira a quatidade de tarefas de prioridade 3 necessária para obter a conquista")]
        public int Priority3 { get; set; }
    }
}
