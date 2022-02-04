using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class TrophyRepository : BaseRepository<TrophyEntity>, ITrophyRepository
    {
        public TrophyRepository(TaskieContext context) : base(context)
        {

        }
    }
}
