using ImmobileApp.Comunication.Requests;

namespace ImmobileApp.Aplication.UseCases.Users.Put.Interfaces
{
    public interface IUpdateUserUseCase
    {
        Task execute(UserRequestJson body, Guid userId);
    }
}
