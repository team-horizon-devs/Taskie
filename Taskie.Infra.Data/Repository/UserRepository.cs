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

        public async Task<UserEntity> GetUserByAsync(string id)
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

    }
}
