using AutoMapper;
using ImmobileApp.Aplication.UseCases.Users.Get.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.LongResponses;
using ImmobileApp.Comunication.Responses.PaginatedResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Repositories;

namespace ImmobileApp.Aplication.UseCases.Users.Get
{
    public class ListUsersWithPaginationUseCase : IListUsersWithPaginationUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public ListUsersWithPaginationUseCase(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserPaginatedResponse> execute(PaginationParams paginationParams)
        {
            var response = await _repository.ListAllUsers(paginationParams);
            var mappedUsers = _mapper.Map<List<UserLongResponseJson>>(response.Users);
            return new UserPaginatedResponse
            {
                Users = mappedUsers,
                PaginationParams = paginationParams,
                TotalAmount = response.TotalAmount,
                PageNumber = response.PageNumber
            };
        }
    }
}
