using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Achievement;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IAchievementUserRepository
    {
        Task<AchievementUserEntity> Create(AchievementUserEntity obj);
        Task<IEnumerable<AchievementEntity>> GetAllAchievementsByUserIdAsync(string userId);
        Task<IEnumerable<AchievementEntity>> GetAllAchievementsNotObtainedByUserIdAsync(string userId);
    }
}
