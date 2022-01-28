using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities.Enums;

namespace Taskie.Domain.Entities
{
    class Task : BaseEntity
    {
        public string Tittle { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public bool Finished { get; set; }
        public bool FinishedInTime { get; set; }
        public DateTime Deadline { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
