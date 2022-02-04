using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IAchievementUserRepository
    {
        void Create(AchievementUser obj);
        Task<IEnumerable<AchievementUser>> GetAllAsync();
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<AchievementUser>> GetAllAchievementsByUserIdAsync(string userId);
    }
}
