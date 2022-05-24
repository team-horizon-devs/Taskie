using System.Collections.Generic;
using Taskie.Domain.Dto.Trophy;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface ITrophyUserRepository
    {
        Task<TrophyUserEntity> CreateAsync(TrophyUserEntity trophyEntity);
        Task<IEnumerable<TrophyEntity>> GetAllTrophiesByUserIdAsync(string idUser);
        Task<IEnumerable<TrophyEntity>> GetAllTrophiesNotObtainedByUserIdAsync(string idUser);
    }
}
