using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;
using Taskie.Domain.Interfaces.Service;

namespace Taskie.Service.Services
{
    public class UserService : IUserService
    {
        public Task<bool> ConfirmEmail()
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> CreateUser(UserCreateDto user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DisabledUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> SumPonits(UserUpdateDto user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAvatar(UserUpdateDto user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateUser(UserUpdateDto user)
        {
            throw new NotImplementedException();
        }
    }
}
