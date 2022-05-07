using System.Threading.Tasks;
using Taskie.Domain.Dto.TrophyUser;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Service
{
    public interface ITrophyUserService
    {
        Task<TrophyUserEntity> CreateTrophyUser(TrophyUserCreateDto trophyUserCreate);

    }
}
