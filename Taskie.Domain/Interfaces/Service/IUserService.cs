using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<UserDto> GetById(string id);
        Task<UserDto> GetByUserName(string userName);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> CreateUser(UserCreateDto userCreateDto);
        Task<UserEntity> UpdateUser(UserUpdateDto userUpdateDto);
        Task<UserEntity> DisabledUser(string id);
        Task<UserDto> AddPonits(string userId, int points);
        Task<UserEntity> UpdateAvatar(UserUpdateDto user);
        Task<UserDto> ConfirmEmail(string userid, string token);
        void SendEmailConfirmed(UserDto user, string confirmationLink);
        Task<string> GenerateConfirmedToken(string userId);
    }
}
