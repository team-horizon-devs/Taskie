using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IUserPointRepository
    {
        Task<UserPointEntity> CreateAsync(UserPointEntity userPointEntity);

        Task<UserPointEntity> UpdateAsync(UserPointEntity userPointEntity);
        Task<IEnumerable<UserPointEntity>> GetAllPointsByUserIdAsync(string idUser);

    }
}
