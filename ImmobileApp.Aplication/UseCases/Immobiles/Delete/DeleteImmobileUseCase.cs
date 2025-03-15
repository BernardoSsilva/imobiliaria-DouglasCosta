using ImmobileApp.Aplication.UseCases.Immobiles.Delete.Interface;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Delete
{

    public class DeleteImmobileUseCase : IDeleteImmobileUseCase
    {
        private readonly IImmobileRepository _repository;

        public DeleteImmobileUseCase(IImmobileRepository repository)
        {
            _repository = repository;
        }
        public async Task execute(Guid immobileId)
        {
            var immobile = await _repository.GetImmobileById(immobileId);

            if (immobile is null)
            {
                throw new NotFoundException();
            }

            await _repository.DeleteImmobileAsync(immobile);
        }
    }
}