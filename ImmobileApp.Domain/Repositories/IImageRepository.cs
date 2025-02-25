using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Repositories
{
    public interface IImageRepository
    {
        void CreateImage(ImageEnitty data);
        Task<List<ImageEnitty>> ListAllImagesFromImmobile(Guid immobileId);
        Task<ImageEnitty> GetImageById(Guid imageId);
        void DeleteImage(Guid imageId);
    }
}
