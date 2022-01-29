using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly TaskieContext _context;
        private readonly DbSet<T> _dataSet;

        public BaseRepository(TaskieContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public void Create(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(T obj)
        {
            _context.Remove(obj);
            _context.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            return _dataSet.ToArray();
        }

        public void Update(T obj)
        {
            _context.Update(obj);
            _context.SaveChanges();
        }

    }
}
