using ImmobileApp.Aplication.UseCases.Users.Post;
using ImmobileApp.Aplication.UseCases.Users.Post.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ImmobileApp.Aplication
{
    public static class DependencyInjectionExtension
    {

        public static void AddApplication(this IServiceCollection service)
        {
            AddAutoMapper(service);
            AddUseCases(service);
        }

        public static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapper));
        }
        private static void AddUseCases(IServiceCollection service) 
        {
            service.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        }
    }
}
