using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.PaginatedResponses;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Get.Interfaces
{
    public interface IListImmobilesUseCase
    {
        Task<ImmobilePaginatedResponse> execute(PaginationParams paginationParams);
    }
}