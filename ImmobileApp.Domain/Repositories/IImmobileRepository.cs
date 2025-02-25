using ImmobileApp.Comunication;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Domain.Repositories
{
    public interface IImmobileRepository
    {
        void CreateNewImmobile(ImmobileEntity data);

        Task<List<ImmobileEntity>> ListAllImmobiles(PaginationParams pagination);
        Task<ImmobileEntity> GetImmobileById(Guid id);

        void UpdateImmobile(ImmobileEntity data);
        Task<ImmobileEntity> DeleteImmobile(ImmobileEntity data);
    }
}
