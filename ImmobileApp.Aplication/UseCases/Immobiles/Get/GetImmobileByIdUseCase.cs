using AutoMapper;
using ImmobileApp.Aplication.UseCases.Immobiles.Get.Interfaces;
using ImmobileApp.Comunication.Responses.LongResponses;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Get
{
    public class GetImmobileByIdUseCase : IGetImmobileByIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IImmobileRepository _repository;

        public GetImmobileByIdUseCase(IMapper mapper, IImmobileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ImmobileLongResponseJson> execute(Guid immobileId)
        {
            var result = await _repository.GetImmobileById(immobileId);
            if (result is null)
            {
                throw new NotFoundException();
            }

            return _mapper.Map<ImmobileLongResponseJson>(result);
        }
    }
}