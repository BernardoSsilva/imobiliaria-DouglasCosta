using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.PaginatedResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Aplication.UseCases.Images.Get.Interfaces
{
    public interface IListImagesByImmobileUseCase
    {
        Task<List<ImageShortResponseJson>> Execute(Guid immobileId);
    }
}
