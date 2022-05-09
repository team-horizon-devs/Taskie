using System;
using Taskie.Domain.Entities.Enums;

namespace Taskie.Domain.Dto.Task
{
    public class TaskDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public PriorityEnum Priority { get; set; }

        public DateTime? Finished { get; set; } = null;

        public bool? FinishedInTime { get; set; } = null;

        public DateTime? Deadline { get; set; }

    }
}
