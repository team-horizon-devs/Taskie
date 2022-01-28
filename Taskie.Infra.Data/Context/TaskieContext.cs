using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Taskie.Domain.Entities;

namespace Taskie.Infra.Data.Context
{
    class TaskieContext : IdentityDbContext<User>
    {

    }
}
