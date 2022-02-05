using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    public class AvatarRepository : BaseRepository<AvatarEntity>, IAvatarRepository
    {
        public AvatarRepository(TaskieContext context) : base(context)
        {

        }
    }
}
