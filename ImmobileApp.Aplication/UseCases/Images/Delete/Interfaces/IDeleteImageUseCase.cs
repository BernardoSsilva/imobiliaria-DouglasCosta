using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmobileApp.Aplication.UseCases.Images.Delete.Interfaces
{
    public interface IDeleteImageUseCase
    {
        public Task<bool> DeleteImage(Guid imageId, string cloudnaryUrl);
    }
}
