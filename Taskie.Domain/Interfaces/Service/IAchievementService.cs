using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.Achievement;

namespace Taskie.Domain.Interfaces.Service
{
    public interface IAchievementService
    {
        Task<AchievementDto> GetById(int id);
        Task<IEnumerable<AchievementDto>> GetAll();
        Task<IEnumerable<AchievementDto>> GetAllObtainedByUserId(string idUser);
        Task<IEnumerable<AchievementDto>> GetAllNotObtainedByUserId(string idUser);
        Task<AchievementDto> CrateAchievement(AchievementCreateDto achievementCreate);
        Task<AchievementDto> UpdateAchievement(AchievementUpdateDto achieventUpdate);
        Task<bool> RemoveAchievement(int idAchievement);
    }
}
