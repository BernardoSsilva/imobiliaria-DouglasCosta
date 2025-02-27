using ImmobileApp.Domain.Repositories;
using ImmobileApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ImmobileApp.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection service)
        {
            AddRepositories(service);
        }

        private static void AddRepositories(IServiceCollection service)
        {
            service.AddScoped<IImageRepository, ImageRepository>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IImmobileRepository, ImmobileRepository>();
        }
    }
}
