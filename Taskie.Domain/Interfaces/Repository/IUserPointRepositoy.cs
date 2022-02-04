using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IUserPointRepository
    {
        void Create(UserPoint obj);

        void Update(UserPoint obj);
        Task<IEnumerable<UserPoint>> GetAllPointsByUserIdAsync(string userId);

    }
}
