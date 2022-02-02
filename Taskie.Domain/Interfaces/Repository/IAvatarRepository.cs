using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IAvatarRepository
    {
        void Create(Avatar avatar);
        void Update(Avatar avatar);
        void Delete(int id);
        Task<Avatar> GetIdAsync(int id);
        Task<IEnumerable<Avatar>> GetAllAsync();
        Task<Avatar> SeachByDescriptionAsync(string description);
        Task<bool> ExistAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
