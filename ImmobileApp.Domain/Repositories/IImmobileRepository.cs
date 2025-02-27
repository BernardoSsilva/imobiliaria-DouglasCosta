using ImmobileApp.Comunication;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Repositories
{
    public interface IImmobileRepository
    {
        Task CreateNewImmobile(ImmobileEntity data);

        Task<List<ImmobileEntity>> ListAllImmobiles(PaginationParams pagination);
        Task<ImmobileEntity?> GetImmobileById(Guid id);

        Task UpdateImmobile(ImmobileEntity data);
        Task DeleteImmobileAsync(ImmobileEntity data);
    }
}
