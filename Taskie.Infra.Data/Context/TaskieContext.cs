using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public DbSet<UserEntity> User { get; set; }


        public TaskieContext(DbContextOptions<TaskieContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrophyUserEntity>().HasKey(tu => new {tu.UserId, tu.TrophyId});
            builder.Entity<AchievementUserEntity>().HasKey(au => new { au.UserId, au.AchievementId });

            builder.Entity<AvatarEntity>().HasData(new AvatarEntity
            {
                Id = 1,
                Image = "https://live.staticflickr.com/65535/51885254260_cb60cd62df_t.jpg",
                Desciption = "Default Image",
                CreatedAt = DateTime.Parse(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"))
        });
        }

    }
}
