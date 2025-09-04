using ImmobileApp.Comunication.Requests;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Domain.Responses.RawResponses;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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

        public async Task<ImmobilePaginatedResponse> ListAllImmobiles(PaginationParams pagination)
        {
            var totalCount = await _dbContext.Immobiles.CountAsync();

            var response = await _dbContext.Immobiles.Skip((pagination.Page - 1) * pagination.PerPage).Take(pagination.PerPage).ToListAsync();
            return new ImmobilePaginatedResponse()
            {
                immobiles = response,
                PageNumber = (int)Math.Ceiling((decimal)totalCount / pagination.PerPage),
                paginationParams = pagination,
                TotalAmount = totalCount
            }
                ;
        }

        public async Task UpdateImmobile(ImmobileEntity data)
        {
            var immobile = await _dbContext.Immobiles.FindAsync(data.Id);

            if (immobile == null)
            {
                return;
            }
            immobile.Street = data.Street;
            immobile.LocalLink = data.LocalLink;
            immobile.City = data.City;
            immobile.Value = data.Value;
            immobile.HasScripture = data.HasScripture;
            immobile.ImmobileDescription = data.ImmobileDescription;
            immobile.ImmobileType = data.ImmobileType;
            immobile.LocalityInfo = data.LocalityInfo;
            immobile.LocalLink = data.LocalLink;
            immobile.Neighborhood = data.Neighborhood;
            immobile.PostalCode = data.PostalCode;
            immobile.State = data.State;
            immobile.Street = data.Street;
            immobile.UpdateDate = DateTime.UtcNow;
            immobile.Value = data.Value;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ImmobileEntity?> GetImmobileByPostalCode(string PostalCode)
        {
            return await _dbContext.Immobiles.FirstOrDefaultAsync(e => e.PostalCode == PostalCode);
        }


    }
}
