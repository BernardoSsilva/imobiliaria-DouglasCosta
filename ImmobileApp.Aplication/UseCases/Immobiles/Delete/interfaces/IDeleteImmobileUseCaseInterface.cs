namespace ImmobileApp.Aplication.UseCases.Immobiles.Delete.Interface
{
    public interface IDeleteImmobileUseCase
    {
        Task execute(Guid immobileId);
    }
}