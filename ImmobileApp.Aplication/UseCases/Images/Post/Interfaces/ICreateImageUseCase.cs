using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;

namespace ImmobileApp.Aplication.UseCases.Images.Post.Interfaces
{
    public interface ICreateImageUseCase
    {
        public Task<ImageShortResponseJson> Execute(ImageRequestJson requestData, string cloudnaryUrl, string immobileId);
    }
}
