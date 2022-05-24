using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository

{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskieContext _context;   

        public TaskRepository(TaskieContext context)
        {
            _context = context;
        }

        public async Task<TaskEntity> CreateAsync(TaskEntity task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }
        public async Task<TaskEntity> UpdateAsync(TaskEntity task)
        {
            _context.Update(task);
            await _context.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<TaskEntity> GetByIdAsync(int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);

            return task;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllByUserAsync(string idUser)
        {
            IQueryable<TaskEntity> tasks = _context.Tasks.Where(t => t.UserId == idUser)
                                           .OrderBy(t => t.CreatedAt);

            return await tasks.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByFinishAsync(string idUser)
        {
            IQueryable<TaskEntity> task = _context.Tasks.Where(t => t.UserId == idUser)
                                          .Where(t => t.Finished != null).OrderBy(t => t.CreatedAt);

            return await task.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByFinishedInTimeAsync(string idUser, bool inTime)
        {
            IQueryable<TaskEntity> tasks = _context.Tasks.Where(t => t.UserId == idUser)
                                            .Where(T => T.FinishedInTime == inTime);

            return await tasks.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByFinishedInTimeByPriorityAsync(int priority)
        {
            IQueryable<TaskEntity> query = _context.Tasks;
            query = query.Where(T => T.FinishedInTime == true && T.Priority.Equals(priority));
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByFinishedInTimeByPriorityAsync(string idUser, int priority)
        {
            IQueryable<TaskEntity> query = _context.Tasks.Where(t => t.UserId == idUser)
                    .Where(t => t.FinishedInTime == true && t.Priority.Equals(priority));

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetByPriorityAsync(string idUser, int priority)
        {
            IQueryable<TaskEntity> tasks = _context.Tasks.Where(t => t.UserId == idUser)
                                            .Where(t => t.Priority.Equals(priority));

            return await tasks.AsNoTracking().ToListAsync();
        }

    }
}
