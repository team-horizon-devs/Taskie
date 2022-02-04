using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntityEntity
    {
        public readonly TaskieContext _context;
        public readonly DbSet<T> _dataSet;

        public BaseRepository(TaskieContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public void Create(T obj)
        {
            _dataSet.Add(obj);
        }

        public void Update(T obj)
        {
            _dataSet.Update(obj);
        }

        public void Delete(int id)
        {
            var obj = _dataSet.FirstOrDefault(ds => ds.Id == id);
            _context.Remove(obj);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await _dataSet.AnyAsync(ds => ds.Id == id);
        }
        public async Task<T> GetIdAsync(int id)
        {
            return await _dataSet.FirstOrDefaultAsync(ds => ds.Id == id);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dataSet.ToListAsync();
        }

    }
}
