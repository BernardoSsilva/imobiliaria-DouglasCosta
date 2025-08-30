using ImmobileApp.Comunication.Requests;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Domain.Responses.RawResponses;
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
            if(user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<UserEntity?> GetUserById(Guid id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (user is null)
            {
                return null;
            }
            return user;
        }

        public async Task<UserPaginatedResponse> ListAllUsers(PaginationParams pagination)
        {
            var totalCount = await _dbContext.Users.CountAsync();

            var users = await _dbContext.Users
                  .Skip((pagination.Page - 1) * pagination.PerPage)
                  .Take(pagination.PerPage)
                  .ToListAsync();

            return new UserPaginatedResponse
            {
                PageNumber = (int)Math.Ceiling((decimal)totalCount / pagination.PerPage),
                PaginationParams = pagination,
                TotalAmount = totalCount,
                Users = users,
            };
        }

        public async Task UpdateUser(UserEntity data)
        {
            _dbContext.Users.Update(data);
            await _dbContext.SaveChangesAsync();


        }

    }
}
