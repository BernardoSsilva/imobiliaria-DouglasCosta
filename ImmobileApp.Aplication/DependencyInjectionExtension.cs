using ImmobileApp.Aplication.UseCases.Users.Delete;
using ImmobileApp.Aplication.UseCases.Users.Delete.Interfaces;
using ImmobileApp.Aplication.UseCases.Users.Get;
using ImmobileApp.Aplication.UseCases.Users.Get.Interfaces;
using ImmobileApp.Aplication.UseCases.Users.Post;
using ImmobileApp.Aplication.UseCases.Users.Post.Interfaces;
using ImmobileApp.Aplication.UseCases.Users.Put;
using ImmobileApp.Aplication.UseCases.Users.Put.Interfaces;
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
            service.AddScoped<IListUsersWithPaginationUseCase, ListUsersWithPaginationUseCase>();
            service.AddScoped<IFindUserByIdUseCase, FindUserByIdUseCase>();
            service.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();
            service.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        }
    }
}
