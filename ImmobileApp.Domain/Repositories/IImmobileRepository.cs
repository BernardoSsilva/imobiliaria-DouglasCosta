using ImmobileApp.Comunication.Requests;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Responses.RawResponses;

namespace ImmobileApp.Domain.Repositories
{
    public interface IImmobileRepository
    {
        Task CreateNewImmobile(ImmobileEntity data);

        Task<ImmobilePaginatedResponse> ListAllImmobiles(PaginationParams pagination);
        Task<ImmobileEntity?> GetImmobileById(Guid id);
        Task<ImmobileEntity?> GetImmobileByPostalCode(string PostalCode);

        Task UpdateImmobile(ImmobileEntity data);
        Task DeleteImmobileAsync(ImmobileEntity data);
    }
}
