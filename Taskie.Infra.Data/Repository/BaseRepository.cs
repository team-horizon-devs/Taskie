using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public readonly TaskieContext _context;
        public readonly DbSet<T> _dataSet;

        public BaseRepository(TaskieContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T obj)
        {
            try
            {
                _dataSet.Add(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public async Task<T> UpdateAsync(T obj)
        {
            try 
            { 
                _dataSet.Update(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var obj = _dataSet.FirstOrDefault(ds => ds.Id == id);
                _dataSet.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

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
