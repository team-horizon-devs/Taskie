using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taskie.Domain.Interfaces.Repository
{
    public interface IRepository<T> where T : class
    {
        public void Create(T obj);
        public void Update(T obj);
        public void Delete(T obj);
        public IEnumerable<T> GetAll();
    }
}
