using System;
using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD
=======
using Taskie.Domain.Dto.User;
>>>>>>> develop
using Taskie.Domain.Entities.Enums;

namespace Taskie.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        [Required]
<<<<<<< HEAD
        [MaxLength(80)]
=======
        [StringLength(80, ErrorMessage = "Título da tarefa deve ter no máximo {1} caracteres.")]
>>>>>>> develop
        public string Tittle { get; set; }

        public string Description { get; set; }

        [Required]
        public PriorityEnum Priority { get; set; }
<<<<<<< HEAD
        public bool Finished { get; set; } = false;
        public bool FinishedInTime { get; set; }
        public DateTime Deadline { get; set; }
=======

        public DateTime? Finished { get; set; } = null;

        public bool? FinishedInTime { get; set; } = null;

        public DateTime? Deadline { get; set; }

>>>>>>> develop
        public string UserId { get; set; }

        public UserEntity User { get; set; }
    }
}
