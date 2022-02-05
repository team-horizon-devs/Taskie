using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface ITaskRepository : IBaseRepository<TaskEntity>
    {
        Task<IEnumerable<TaskEntity>> GetByPriorityAsync(int Priority);
        Task<IEnumerable<TaskEntity>> GetByFinishAsync(bool Test);
        Task<IEnumerable<TaskEntity>> GetByFinishedInTimeAsync(bool Test);
        Task<IEnumerable<TaskEntity>> GetByFinishedInTimeByPriorityAsync(int Priority);
    }
}
