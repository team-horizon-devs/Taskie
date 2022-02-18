using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Dto.User;

namespace Taskie.Domain.Interfaces.Service
{
    public interface IUserService
    {
        Task<UserDtoCreate> Get(String id);
        Task<IEnumerable<UserDtoCreate>> GetAll();
    }
}
