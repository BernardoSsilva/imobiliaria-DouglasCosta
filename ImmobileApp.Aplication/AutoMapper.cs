using AutoMapper;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.LongResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;

namespace ImmobileApp.Aplication
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            EntityToResponse();
            RequestToEntity();
        }

        public void EntityToResponse()
        {
            CreateMap<UserEntity, UserShortResponseJson>();
            CreateMap<UserEntity, UserLongResponseJson>();
            CreateMap<ImmobileEntity, ImmobileLongResponseJson>();
            CreateMap<ImmobileEntity, ImmobileShortResponseJson>();
            CreateMap<ImageEnitty, ImageShortResponseJson>();
        }
        public void RequestToEntity()
        {
            CreateMap<UserRequestJson, UserEntity>();
            CreateMap<ImmobileRequestJson, ImmobileEntity>();
            CreateMap<ImageRequestJson, ImageEnitty>();

        }
    }
}
