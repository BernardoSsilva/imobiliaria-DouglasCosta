using AutoMapper;
using ImmobileApp.Aplication.UseCases.Immobiles.Get.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.PaginatedResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Repositories;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Get
{
    public class ListImmobilesUseCase : IListImmobilesUseCase
    {
        private readonly IImmobileRepository _repository;
        private readonly IMapper _mapper;
        public ListImmobilesUseCase(IMapper mapper, IImmobileRepository repository)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ImmobilePaginatedResponse> execute(PaginationParams paginationParams)
        {
            var result = await _repository.ListAllImmobiles(paginationParams);

            var parsedData = _mapper.Map<List<ImmobileShortResponseJson>>(result.immobiles);

            return new ImmobilePaginatedResponse
            {
                immobiles = parsedData,
                paginationParams = paginationParams,
                PageNumber = result.PageNumber,
                TotalAmount = result.TotalAmount
            };
        }
    }
}