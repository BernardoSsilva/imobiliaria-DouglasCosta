using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Post.Interfaces
{
    public interface ICreateImmobileUseCase
    {
        Task<ImmobileShortResponseJson> execute(Guid userId, ImmobileRequestJson request);
    }
}