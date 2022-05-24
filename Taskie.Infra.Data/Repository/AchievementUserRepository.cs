using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Achievement;
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

        public async Task<AchievementUserEntity> Create(AchievementUserEntity achievement)
        {
            _context.AchievementsUsers.Add(achievement);
            await _context.SaveChangesAsync();

            return achievement;
        }

        public async Task<IEnumerable<AchievementEntity>> GetAllAchievementsByUserIdAsync(string userId)
        {
            IQueryable<AchievementUserEntity> query = _context.AchievementsUsers;
            query = query.Include(au => au.Achievement).Where(a => a.UserId == userId);
            IEnumerable<AchievementEntity> achievements = await _context.Achievements.ToListAsync();

            List<AchievementEntity> obtained = (from AchievementEntity achievement in achievements
                                                      from achievementUser in query
                                                      where achievement.Id == achievementUser.AchievementId
                                                      select achievement).ToList();

            return obtained;
        }

        public async Task<IEnumerable<AchievementEntity>> GetAllAchievementsNotObtainedByUserIdAsync(string userId)
        {
            IQueryable<AchievementUserEntity> query = _context.AchievementsUsers;
            query = query.Include(au => au.Achievement).Where(a => a.UserId == userId);
            IEnumerable<AchievementEntity> achievements = await _context.Achievements.ToListAsync();

            List<AchievementEntity> notObtained = (from AchievementEntity achievement in achievements
                                                   let obtIds = from achievementUser in query
                                                                select achievementUser.AchievementId
                                                   where obtIds.Contains(achievement.Id) == true
                                                   select achievement).ToList();

            return notObtained;
        }
    }
}
