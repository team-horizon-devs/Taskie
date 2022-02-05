using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taskie.Domain.Entities;

namespace Taskie.Infra.Data.Context
{
    public class TaskieContext : IdentityDbContext
    {
        public DbSet<AchievementEntity> Achievements { get; set; }
        public DbSet<AchievementUserEntity> AchievementsUsers { get; set; }
        public DbSet<AvatarEntity> Avatars { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<TrophyEntity> Trophies { get; set; }
        public DbSet<TrophyUserEntity> TrophiesUsers { get; set; }
        public DbSet<UserPointEntity> UsersPoints { get; set; }

        public TaskieContext(DbContextOptions<TaskieContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrophyUserEntity>().HasKey(tu => new {tu.UserId, tu.TrophyId});
            builder.Entity<AchievementUserEntity>().HasKey(au => new { au.UserId, au.AchievementId });
            builder.Entity<UserPointEntity>().HasKey(up => new { up.UserId});
        }

    }
}
