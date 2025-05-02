using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.PaginatedResponses;

namespace ImmobileApp.Aplication.UseCases.Images.Get.Interfaces
{
    public interface IListImagesByImmobileUseCase
    {
        Task<ImagePaginatedResponse> Execute(PaginationParams paginationParams, Guid immobileId);
    }
}
