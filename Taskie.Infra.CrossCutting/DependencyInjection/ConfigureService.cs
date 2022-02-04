using Microsoft.Extensions.DependencyInjection;

namespace Taskie.Infra.CrossCutting.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddServices(this IServiceCollection service)
        {
            return service;
        }
    }
}
