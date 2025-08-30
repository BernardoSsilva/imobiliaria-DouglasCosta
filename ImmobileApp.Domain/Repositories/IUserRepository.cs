using ImmobileApp.Comunication.Requests;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Responses.RawResponses;

namespace ImmobileApp.Domain.Repositories
{
    public interface IUserRepository
    {
        Task CreateNewUser(UserEntity data);

        Task<UserPaginatedResponse> ListAllUsers(PaginationParams pagination);

        Task<UserEntity?> GetUserById(Guid id);

        Task<UserEntity?> GetUserByEmail(string userEmail);

        Task UpdateUser(UserEntity data);

        Task DeleteUser(UserEntity data);
        
    }
}
