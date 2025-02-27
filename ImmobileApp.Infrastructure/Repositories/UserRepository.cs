using ImmobileApp.Comunication;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImmobileApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ImmobileAppDbContext _dbContext;

        public UserRepository(ImmobileAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateNewUser(UserEntity data)
        {
            await _dbContext.Users.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(UserEntity data)
        {
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

       

        public async Task<UserEntity?> GetUserByEmail(string userEmail)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserEmail == userEmail);
            return user;
        }

        public async Task<UserEntity?> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            return user;
        }

        public async Task<List<UserEntity>> ListAllUsers(PaginationParams pagination)
        {
            var users =await _dbContext.Users.Take(pagination.PerPage).Skip((pagination.Page - 1) * pagination.PerPage).ToListAsync();
            return users;
        }

        public async Task UpdateUser(UserEntity data)
        {
            _dbContext.Users.Update(data);
            await _dbContext.SaveChangesAsync();


        }

    }
}
