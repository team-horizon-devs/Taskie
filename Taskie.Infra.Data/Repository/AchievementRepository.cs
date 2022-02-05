using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class AchievementRepository : BaseRepository<AchievementEntity>, IAchievementRepository
    {
        public AchievementRepository(TaskieContext context) : base(context)
        {
        }
    }
}
