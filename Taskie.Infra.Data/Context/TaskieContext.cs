using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taskie.Domain.Entities;

namespace Taskie.Infra.Data.Context
{
    class TaskieContext : IdentityDbContext<User>
    {
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AchievementUser> AchievementsUsers { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        public DbSet<FinishedInTime> FinishedsInTime { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<TrophyUser> TrophiesUsers { get; set; }
        public DbSet<UserPoint> UsersPoints { get; set; }

        public TaskieContext(DbContextOptions<TaskieContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TrophyUser>().HasKey(tu => new {tu.UserId, tu.TrophyId});
            builder.Entity<AchievementUser>().HasKey(au => new { au.UserId, au.AchievementId });
            
        }




    }
}
