using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;

namespace Taskie.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<UserDto> GetById(string id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<bool> CreateUser(UserCreateDto user);
        Task<bool> UpdateUser(UserUpdateDto user);
        Task<bool> DisabledUser(string id);
        Task<bool> SumPonits(UserUpdateDto user);
        Task<bool> UpdateAvatar(UserUpdateDto user);
        Task<bool> ConfirmEmail();
    }
}
