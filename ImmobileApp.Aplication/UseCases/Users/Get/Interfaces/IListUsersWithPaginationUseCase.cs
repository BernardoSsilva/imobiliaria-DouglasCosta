using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.PaginatedResponses;

namespace ImmobileApp.Aplication.UseCases.Users.Get.Interfaces
{
    public interface IListUsersWithPaginationUseCase
    {
        Task<UserPaginatedResponse> execute(PaginationParams paginationParams);
    }
}
