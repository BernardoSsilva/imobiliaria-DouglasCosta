using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Repositories
{
    public interface IImageRepository
    {
        void CreateImage(ImagesEnitty data);
        Task<List<ImagesEnitty>> ListAllImagesFromImmobile(Guid immobileId);
        Task<ImagesEnitty> GetImageById(Guid imageId);
        void DeleteImage(Guid imageId);
    }
}
