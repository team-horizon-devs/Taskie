using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taskie.Domain.Entities;

namespace Taskie.Infra.Data.Context
{
    public class TaskieContext : IdentityDbContext
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementUser> AchievementsUsers { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<TrophyUser> TrophiesUsers { get; set; }
        public DbSet<UserPoint> UsersPoints { get; set; }

        public TaskieContext(DbContextOptions<TaskieContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrophyUser>().HasKey(tu => new {tu.UserId, tu.TrophyId});
            builder.Entity<AchievementUser>().HasKey(au => new { au.UserId, au.AchievementId });
            builder.Entity<UserPoint>().HasKey(up => new { up.UserId});
        }

    }
}
