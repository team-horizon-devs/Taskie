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
    public class AvatarRepository : BaseRepository<AvatarEntity>, IAvatarRepository
    {
        public AvatarRepository(TaskieContext context) : base(context)
        {

        }
    }
}
