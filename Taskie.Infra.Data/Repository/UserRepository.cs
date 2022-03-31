using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskieContext _context;

        public UserRepository(TaskieContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> GetUserByIdAsync(string id)
        {
            var user = await _context.User.Include(u => u.Avatar)
                .Include(u => u.TrophiesUser).ThenInclude(tu => tu.Trophy)
                .Include(u => u.AchievementsUser).ThenInclude(au => au.Achievement).FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

        public async Task<IEnumerable<UserEntity>> GetAllUserAsync()
        {
            var user = await _context.User.Include(u => u.Avatar)
                .Include(u => u.TrophiesUser).ThenInclude(tu => tu.Trophy)
                .Include(u => u.AchievementsUser).ThenInclude(au => au.Achievement).AsNoTracking().ToListAsync();

            return user;
        }

        public async Task<UserEntity> GetUserByUserNameAsync(string userName)
        {
            var user = await _context.User.Include(u => u.Avatar)
            .Include(u => u.TrophiesUser).ThenInclude(tu => tu.Trophy)
            .Include(u => u.AchievementsUser).ThenInclude(au => au.Achievement)
            .FirstOrDefaultAsync(u => u.NormalizedUserName == userName.ToUpper());

            return user;
        }

        public async Task<bool> UpdatePointsAsync(string userId, int points)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == userId);
            user.Point += points;
            _context.User.Update(user);

            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> UpdateAvatarAsync(string userId, int avatarId)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == userId);
            user.AvatarId = avatarId;
            _context.User.Update(user);

            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> DisableUserAsync(string userId)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == userId);
            user.Active = false;
            _context.User.Update(user);

            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
