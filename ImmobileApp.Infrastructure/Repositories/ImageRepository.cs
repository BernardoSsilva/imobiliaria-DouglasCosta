using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ImmobileApp.Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ImmobileAppDbContext _dbContext;

        public ImageRepository(ImmobileAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateImage(ImageEnitty data)
        {
            _dbContext.Images.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteImage(ImageEnitty data)
        {
            
            _dbContext.Remove(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ImageEnitty?> GetImageById(Guid imageId)
        {
            var result = await _dbContext.Images.FirstOrDefaultAsync(i => i.Id == imageId);
            return result;
        }

        public async Task<List<ImageEnitty>> ListAllImagesFromImmobile(Guid immobileId)
        {
            var result = await _dbContext.Images.Where(i => i.ImmobileId == immobileId).ToListAsync();
            return result;
        }
    }
}
