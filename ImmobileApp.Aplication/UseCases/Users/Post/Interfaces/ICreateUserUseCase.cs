using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Aplication.UseCases.Users.Post.Interfaces
{
    public interface ICreateUserUseCase
    {
        Task<UserShortResponseJson> execute(UserRequestJson data);
    }
}
