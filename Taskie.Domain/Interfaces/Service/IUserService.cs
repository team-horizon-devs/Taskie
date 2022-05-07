using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.TrophyUser;
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
        Task<IdentityResult> UpdateUser(UserUpdateDto userUpdateDto);
        Task<bool> DisabledUser(string id);
        Task<bool> UpdateAvatar(string userId, int avatarId);
        Task<bool> ConfirmEmail(string userid, string token);
        void SendEmailConfirmed(UserDto user, string confirmationLink);
        Task<string> GenerateConfirmedToken(string userId);
        Task<bool> ChangePassword(UserUpdatePassword userUpdatePassword);
        Task<bool> BuyTrophies(TrophyUserCreateDto trophyUserCreate);
    }
}
