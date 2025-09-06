using ImmobileApp.Comunication.Requests;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Repositories
{
    public interface IImageRepository
    {
        Task CreateImage(ImageEnitty data);
        Task<List<ImageEnitty>> ListAllImagesFromImmobile(Guid immobileId);
        Task<ImageEnitty?> GetImageById(Guid imageId);
        Task DeleteImage(ImageEnitty data);
    }
}
