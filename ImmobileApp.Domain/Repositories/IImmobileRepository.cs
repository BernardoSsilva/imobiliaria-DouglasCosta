using ImmobileApp.Comunication;
using ImmobileApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
