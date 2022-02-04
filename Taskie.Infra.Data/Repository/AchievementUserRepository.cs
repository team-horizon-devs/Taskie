using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    class AchievementUserRepository : IAchievementUserRepository
    {
        private readonly TaskieContext _context;

        public AchievementUserRepository(TaskieContext context)
        {
            _context = context;
        }

        public void Create(AchievementUser obj)
        {
            _context.AchievementsUsers.Add(obj);
        }

        public async Task<IEnumerable<AchievementUser>> GetAllAsync()
        {
            return await _context.AchievementsUsers.ToListAsync();
        }

        public async Task<IEnumerable<AchievementUser>> GetAllAchievementsByUserIdAsync(string userId)
        {
            IQueryable<AchievementUser> query = _context.AchievementsUsers;
            query = query.Include(au => au.Achievement).Where(a => a.UserId == userId);

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
