using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class UserPointRepository : IUserPointRepository
    {
        private readonly TaskieContext _context;

        public void Create(UserPoint obj)
        {
            _context.UsersPoints.Add(obj);
        }

        public async Task<IEnumerable<UserPoint>> GetAllPointsByUserIdAsync(string userId)
        {
            IQueryable<UserPoint> query = _context.UsersPoints;
            query = query.Include(up => up.Points).Where(p => p.UserId == userId);

            return await query.AsNoTracking().ToListAsync();
        }

        public void Update(UserPoint obj)
        {
            _context.UsersPoints.Update(obj);
        }
    }
}
