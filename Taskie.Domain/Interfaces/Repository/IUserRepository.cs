using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {

        Task<UserEntity> GetUserByIdAsync(string id);

        Task<UserEntity> GetUserByUserNameAsync(string userName);

        Task<IEnumerable<UserEntity>> GetAllUserAsync();

    }
}
