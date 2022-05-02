using Microsoft.Extensions.DependencyInjection;
using Taskie.Domain.Interfaces.Service;
using Taskie.Service.Services;

namespace Taskie.Infra.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAchievementService, AchievementService>();
            services.AddScoped<IAvatarService, AvatarService>();

            return services;
        }
    }
}
