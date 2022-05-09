using System;
using System.ComponentModel.DataAnnotations;
using Taskie.Domain.Entities.Enums;

namespace Taskie.Domain.Dto.Task
{
    public class TaskCreateDto
    {
        [Required]
        [StringLength(80, ErrorMessage = "Título da tarefa deve ter no máximo {1} caracteres.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public PriorityEnum Priority { get; set; }

        [Required]
        public DateTime? Deadline { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
