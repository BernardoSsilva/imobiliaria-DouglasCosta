namespace ImmobileApp.Aplication.UseCases.Users.Delete.Interfaces
{
    public interface IDeleteUserUseCase
    {
        Task execute(Guid userId);

    }
}
