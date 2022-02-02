using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository.Implementations
{
    public class AvatarRepository : IAvatarRepository
    {
        private readonly TaskieContext _context;
        private readonly IBaseRepository<Avatar> _baseRepository;

        public AvatarRepository(IBaseRepository<Avatar> repository, TaskieContext context)
        {
            _baseRepository = repository;
            _context = context;
        }

        public void Create(Avatar avatar)
        {
            _baseRepository.Create(avatar);
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public Task<bool> ExistAsync(int id)
        {
            return _baseRepository.ExistAsync(id);
        }

        public Task<IEnumerable<Avatar>> GetAllAsync()
        {
            return _baseRepository.GetAllAsync();
        }

        public Task<Avatar> GetIdAsync(int id)
        {
            return _baseRepository.GetIdAsync(id);
        }

        public Task<bool> SaveChangesAsync()
        {
            return _baseRepository.SaveChangesAsync();
        }

        public async Task<Avatar> SeachByDescriptionAsync(string description)
        {
            var obj = await _context.Avatars
                .FirstOrDefaultAsync(a => a.Desciption.ToLower().Contains(description.ToLower()));

            return obj;
        }

        public void Update(Avatar avatar)
        {
            _baseRepository.Update(avatar);
        }
    }
}
