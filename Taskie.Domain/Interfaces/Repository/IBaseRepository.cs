using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
        Task<T> GetIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> ExistAsync(int id);
        Task<bool> SaveChangesAsync();

    }
}
