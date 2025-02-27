using ImmobileApp.Comunication;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImmobileApp.Infrastructure.Repositories
{
    public class ImmobileRepository : IImmobileRepository
    {
        private readonly ImmobileAppDbContext _dbContext;

        public ImmobileRepository(ImmobileAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateNewImmobile(ImmobileEntity data)
        {
            await _dbContext.Immobiles.AddAsync(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteImmobileAsync(ImmobileEntity data)
        {
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ImmobileEntity?> GetImmobileById(Guid id)
        {
            var response = await _dbContext.Immobiles.FirstOrDefaultAsync(e => e.Id == id);
            return response;
        }

        public async Task<List<ImmobileEntity>> ListAllImmobiles(PaginationParams pagination)
        {
            var response = await _dbContext.Immobiles.Take(pagination.PerPage).Skip((pagination.Page - 1) * pagination.PerPage).ToListAsync();
            return response;
        }

        public async Task UpdateImmobile(ImmobileEntity data)
        {
            _dbContext.Immobiles.Update(data);
            await _dbContext.SaveChangesAsync();
        }

      
    }
}
