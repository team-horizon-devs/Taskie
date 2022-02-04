using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface ITrophyUserRepository
    {
        Task<TrophyUserEntity> CreateAsync(TrophyUserEntity trophyEntity);
        Task<IEnumerable<TrophyUserEntity>> GetAllTrophiesByUserIdAsync(string idUser);

    }
}
