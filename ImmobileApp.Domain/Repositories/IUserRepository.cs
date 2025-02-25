using ImmobileApp.Comunication;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Repositories
{
    public interface IUserRepository
    {
        void CreateNewUser(UserEntity data);

        Task<List<UserEntity>> ListAllUsers(PaginationParams pagination);

        Task<UserEntity> GetUserById(Guid id);

        Task<UserEntity> GetUserByEmail(string userEmail);

        void UpdateUser(UserEntity data);

        Task<UserEntity> DeleteUser(UserEntity data);
        
    }
}
