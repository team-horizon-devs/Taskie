using System;
using System.ComponentModel.DataAnnotations;
using Taskie.Domain.Dto.User;
using Taskie.Domain.Entities.Enums;

namespace Taskie.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        [Required]
        [StringLength(80, ErrorMessage = "Título da tarefa deve ter no máximo {1} caracteres.")]
        public string Tittle { get; set; }

        public string Description { get; set; }

        [Required]
        public PriorityEnum Priority { get; set; }

        public DateTime? Finished { get; set; } = null;

        public bool? FinishedInTime { get; set; } = null;

        public DateTime? Deadline { get; set; }

        public string UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
