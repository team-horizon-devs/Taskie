using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Taskie.Domain.Interfaces.Repository;
using Taskie.Infra.Data.Context;
using Taskie.Infra.Data.Repository;

namespace Taskie.Infra.Data.Extensions
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddEntityFramework
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskieContext>(options => options
                .UseMySql(configuration.GetConnectionString("DefaultConnections"),
                new MySqlServerVersion(new Version(10, 4, 21))));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAvatarRepository, AvatarRepository>();
            services.AddScoped<IAchievementRepository, AchievementRepository>();
            services.AddScoped<IAchievementUserRepository, AchievementUserRepository>();
            services.AddScoped<ITrophyRepository, TrophyRepository>();
            services.AddScoped<ITrophyUserRepository, TrophyUserRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
