using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ImmobileApp.Aplication.UseCases.Images.Post.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;
using System.IO;


namespace ImmobileApp.Aplication.UseCases.Images.Post
{
    public class CreateImageUseCase : ICreateImageUseCase
    {
        private readonly IImageRepository _repository;
        private readonly IImmobileRepository _immobilesRepository;
        public CreateImageUseCase(IImageRepository repository,  IImmobileRepository immobileRepository)
        {
            _repository = repository;
            _immobilesRepository = immobileRepository;
        }

        public async Task<ImageShortResponseJson> Execute(ImageRequestJson requestData, string cloudnaryUrl, string immobileId)
        {
            try
            {

                Cloudinary cloudinary = new Cloudinary(cloudnaryUrl);
                cloudinary.Api.Secure = true;

                var immobileExists = await _immobilesRepository.GetImmobileById(new Guid(immobileId));

                if (immobileExists is null)
                {
                    throw new NotFoundException();
                }

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(requestData.File.FileName, requestData.File.OpenReadStream()),
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                var imageEntity = new ImageEnitty()
                {
                    Id = new Guid(),
                    ImmobileId = new Guid(immobileId),
                    ImageUrl = uploadResult.Uri.ToString(),
                    Size = requestData.File.Length,
                    Name = requestData.File.Name,
                    Type = requestData.File.ContentType,
                    CloudnaryPublicId = uploadResult.PublicId.ToString()

                };

                await _repository.CreateImage(imageEntity);

                return new ImageShortResponseJson()
                {
                    Id = imageEntity.Id,
                    ImageUrl = imageEntity.ImageUrl,
                    ImmobileId = new Guid(immobileId),
                };
            }
            catch
            {
                throw new  System.Exception();
            }
        }
    }
}
