using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class TrhophyRepository : BaseRepository<TrophyEntity>, ITrophyRepository
    {
        public TrhophyRepository(TaskieContext context) : base(context)
        {

        }
    }
}
