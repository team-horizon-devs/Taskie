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
    public class TrophyUserRepository : ITrophyUserRepository
    {
        private readonly TaskieContext _context;

        public TrophyUserRepository(TaskieContext context)
        {
            _context = context;
        }

        public async Task<TrophyUserEntity> CreateAsync(TrophyUserEntity trophyEntity)
        {
            try
            {
                _context.TrophiesUsers.Add(trophyEntity);
                await _context.SaveChangesAsync();
                return trophyEntity;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<TrophyUserEntity>> GetAllTrophiesByUserIdAsync(string idUser)
        {
            IQueryable<TrophyUserEntity> query = _context.TrophiesUsers;
            query = query.Include(tu => tu.Trophy).Where(tu => tu.UserId == idUser);

            return await query.AsNoTracking().ToListAsync();
        }
       
    }
}
