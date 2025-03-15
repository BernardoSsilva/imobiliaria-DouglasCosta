using ImmobileApp.Comunication.Requests;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Put.Interfaces
{
    public interface IUpdateImmobileUseCase
    {
        Task execute(Guid userId, Guid ImmobileId, ImmobileRequestJson request);
    }
}