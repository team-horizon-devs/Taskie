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
        Task<bool> UpdatePointsAsync(string userId, int points);
        Task<bool> UpdateAvatarAsync(string userId, int avatarId);
        Task<bool> DisableUserAsync(string userId);
        Task<bool> UpdatePhoneAsync(string userId, string phoneNumber);

    }
}
