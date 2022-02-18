using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class TaskRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        private readonly DbSet<TaskEntity> _repo;

        public TaskRepository(TaskieContext context) : base(context)
        {
            _repo = context.Tasks;
        }

        public async Task<IEnumerable<TaskEntity>> GetByFinishAsync(bool test)
        {
            IQueryable<TaskEntity> query = _repo;
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByFinishedInTimeAsync(bool test)
        {
            IQueryable<TaskEntity> query = _repo;
            query = query.Where(T => T.FinishedInTime == test);
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByFinishedInTimeByPriorityAsync(int priority)
        {
            IQueryable<TaskEntity> query = _repo;
            query = query.Where(T => T.FinishedInTime == true && T.Priority.Equals(priority));
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByPriorityAsync(int priority)
        {
            IQueryable<TaskEntity> query = _repo;
            query = query.Where(T => T.Priority.Equals(priority));
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
