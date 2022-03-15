using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;

namespace Taskie.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<UserDto> GetById(string id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<IdentityResult> CreateUser(UserCreateDto user);
        Task<IdentityResult> UpdateUser(UserUpdateDto user);
        Task<IdentityResult> DisabledUser(string id);
        Task<IdentityResult> SumPonits(UserUpdateDto user);
        Task<IdentityResult> UpdateAvatar(UserUpdateDto user);
        Task<bool> ConfirmEmail();
    }
}
