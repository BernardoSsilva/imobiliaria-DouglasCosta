using AutoMapper;
using ImmobileApp.Aplication.UseCases.Users.Get.Interfaces;
using ImmobileApp.Comunication.Responses.LongResponses;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Users.Get
{
    public class FindUserByIdUseCase : IFindUserByIdUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public FindUserByIdUseCase(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserLongResponseJson> execute(Guid id)
        {
           var result = await _repository.GetUserById(id);
            if(result is null)
            {
                throw new NotFoundException();
            } else
            {
               return _mapper.Map<UserLongResponseJson>(result);
            }
        }
    }
}
