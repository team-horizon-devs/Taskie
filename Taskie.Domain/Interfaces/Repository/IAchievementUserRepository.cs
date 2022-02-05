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
        Task<AchievementUserEntity> Create(AchievementUserEntity obj);
        Task<IEnumerable<AchievementUserEntity>> GetAllAsync();
        Task<IEnumerable<AchievementUserEntity>> GetAllAchievementsByUserIdAsync(string userId);
    }
}
