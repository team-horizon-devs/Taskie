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
    public class UserPointRepository : IUserPointRepository
    {
        private readonly TaskieContext _context;

        public UserPointRepository(TaskieContext context)
        {
            _context = context;
        }

        public async Task<UserPointEntity> CreateAsync(UserPointEntity userPointEntity)
        {
            try
            {
                _context.UsersPoints.Add(userPointEntity);
                await _context.SaveChangesAsync();
                return userPointEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserPointEntity> UpdateAsync(UserPointEntity userPointEntity)
        {
            try
            {
                _context.UsersPoints.Update(userPointEntity);
                await _context.SaveChangesAsync();
                return userPointEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserPointEntity>> GetAllPointsByUserIdAsync(string idUser)
        {
            IQueryable<UserPointEntity> query = _context.UsersPoints;
            query = query.Include(up => up.Points).Where(p => p.UserId == idUser);

            return await query.AsNoTracking().ToListAsync();
        }

    }
}
