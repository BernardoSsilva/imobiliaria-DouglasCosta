using ImmobileApp.Aplication.UseCases.Immobiles.Delete;
using ImmobileApp.Aplication.UseCases.Immobiles.Delete.Interface;
using ImmobileApp.Aplication.UseCases.Immobiles.Get;
using ImmobileApp.Aplication.UseCases.Immobiles.Get.Interfaces;
using ImmobileApp.Aplication.UseCases.Immobiles.Post;
using ImmobileApp.Aplication.UseCases.Immobiles.Post.Interfaces;
using ImmobileApp.Aplication.UseCases.Immobiles.Put;
using ImmobileApp.Aplication.UseCases.Immobiles.Put.Interfaces;
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
            service.AddScoped<ILoginUseCase, LoginUseCase>();
            service.AddScoped<ICreateImmobileUseCase, CreateImmobileUseCase>();
            service.AddScoped<IListImmobilesUseCase, ListImmobilesUseCase>();
            service.AddScoped<IGetImmobileByIdUseCase, GetImmobileByIdUseCase>();
            service.AddScoped<IDeleteImmobileUseCase, DeleteImmobileUseCase>();
            service.AddScoped<IUpdateImmobileUseCase, UpdateImmobileUseCase>();
        }
    }
}
