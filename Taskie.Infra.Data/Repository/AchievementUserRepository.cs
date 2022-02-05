using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class AchievementUserRepository : IAchievementUserRepository
    {
        private readonly TaskieContext _context;

        public AchievementUserRepository(TaskieContext context)
        {
            _context = context;
        }

        public async Task<AchievementUserEntity> Create(AchievementUserEntity obj)
        {
            try
            {
                _context.AchievementsUsers.Add(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<AchievementUserEntity>> GetAllAsync()
        {
            return await _context.AchievementsUsers.ToListAsync();
        }

        public async Task<IEnumerable<AchievementUserEntity>> GetAllAchievementsByUserIdAsync(string userId)
        {
            IQueryable<AchievementUserEntity> query = _context.AchievementsUsers;
            query = query.Include(au => au.Achievement).Where(a => a.UserId == userId);

            return await query.AsNoTracking().ToListAsync();
        }
    }
}
