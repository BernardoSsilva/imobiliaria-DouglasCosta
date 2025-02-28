using ImmobileApp.Comunication.Responses.LongResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmobileApp.Aplication.UseCases.Users.Get.Interfaces
{
    public interface IFindUserByIdUseCase
    {
        Task<UserLongResponseJson> execute(Guid id);
    }
}
