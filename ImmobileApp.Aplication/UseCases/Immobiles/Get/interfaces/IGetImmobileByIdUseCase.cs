using ImmobileApp.Comunication.Responses.LongResponses;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Get.Interfaces
{
    public interface IGetImmobileByIdUseCase
    {
        Task<ImmobileLongResponseJson> execute(Guid immobileId);
    }
}