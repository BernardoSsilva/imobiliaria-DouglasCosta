using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ImmobileApp.Aplication.UseCases.Images.Get.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.PaginatedResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;

namespace ImmobileApp.Aplication.UseCases.Images.Get
{
    public class ListImagesByImmobileUseCase : IListImagesByImmobileUseCase
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;


        public ListImagesByImmobileUseCase(IImageRepository repository, IMapper mapper)
        {
            _imageRepository = repository;
            _mapper = mapper;
        }
        public async Task<List<ImageShortResponseJson>> Execute( Guid immobileId)
        {
            List<ImageEnitty> response = await this._imageRepository.ListAllImagesFromImmobile( immobileId);
            List<ImageShortResponseJson> parsedImages = _mapper.Map<List<ImageShortResponseJson>>(response);

            return  parsedImages;
        }
    }
}
