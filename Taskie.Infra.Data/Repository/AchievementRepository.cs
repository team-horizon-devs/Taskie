using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskie.Domain.Entities;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;

namespace Taskie.Infra.Data.Repository
{
    class AchievementRepository : BaseRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(TaskieContext context) : base(context)
        {
        }
    }
}
