using ImmobileApp.Comunication;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Repositories
{
    public interface IUserRepository
    {
        Task CreateNewUser(UserEntity data);

        Task<List<UserEntity>> ListAllUsers(PaginationParams pagination);

        Task<UserEntity?> GetUserById(Guid id);

        Task<UserEntity?> GetUserByEmail(string userEmail);

        Task UpdateUser(UserEntity data);

        Task DeleteUser(UserEntity data);
        
    }
}
