using System.Collections.Generic;
using System.Threading.Tasks;
using Taskie.Domain.Entities;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : BaseEntityEntity
    {
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<bool> DeleteAsync(int id);
        Task<T> GetIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> ExistAsync(int id);

    }
}
