using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ImmobileApp.Aplication.UseCases.Images.Delete.Interfaces;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Images.Delete
{
    public class DeleteImageUseCase : IDeleteImageUseCase
    {
        private readonly IImageRepository _repository;
        public DeleteImageUseCase(IImageRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteImage(Guid imageId, string cloudnaryUrl)
        {
            // isso daqui não vai funcionar nem que me paguem

            Cloudinary cloudinary = new Cloudinary(cloudnaryUrl);
            cloudinary.Api.Secure = true;

            var imageToDelete = await _repository.GetImageById(imageId);

            if (imageToDelete is null)
            {
                throw new NotFoundException();
            }
            var exclusionParams = new DeletionParams(imageToDelete.CloudnaryPublicId)
            {
                Invalidate = true,
                ResourceType = ResourceType.Image,
            };

            var deleteResponse = await cloudinary.DestroyAsync(exclusionParams);
            await _repository.DeleteImage(imageToDelete);

            return true;

        }

      
    }
}
