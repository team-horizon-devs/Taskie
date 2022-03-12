using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {

        Task<UserEntity> GetUserByAsync(string id);

        Task<IEnumerable<UserEntity>> GetAllUserAsync();

    }
}
