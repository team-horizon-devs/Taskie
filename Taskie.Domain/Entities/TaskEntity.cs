using System;
using System.ComponentModel.DataAnnotations;
using Taskie.Domain.Entities.Enums;

namespace Taskie.Domain.Entities
{
    public class TaskEntity : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string Tittle { get; set; }
        public string Description { get; set; }
        public PriorityEnum Priority { get; set; }
        public bool Finished { get; set; } = false;
        public bool FinishedInTime { get; set; }
        public DateTime Deadline { get; set; }
        public string UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
