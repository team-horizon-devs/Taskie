using System;
using System.Collections.Generic;

using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface ITrophiesUser
    {
        void Create(TrophyEntity trophy);
        void Update(TrophyEntity trophy);
        void Delete(int id);
        Task<IEnumerable<TrophyUserEntity>> GetAllByUserId(int idUser);
        Task<IEnumerable<TrophyUserEntity>> GetAllByTrophyId(int idTrophy);
    }
}
