using AutoMapper;
using ImmobileApp.Aplication.UseCases.Immobiles.Post.Interfaces;
using ImmobileApp.Aplication.Validators;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Post
{
    public class CreateImmobileUseCase : ICreateImmobileUseCase
    {
        private readonly IImmobileRepository _repository;
        private readonly IMapper _mapper;
        public CreateImmobileUseCase(IImmobileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ImmobileShortResponseJson> execute(Guid userId, ImmobileRequestJson request)
        {
            Validate(request);
            var newImmobileEntity = new ImmobileEntity
            {
                City = request.City,
                CreationDate = DateTime.UtcNow,
                HasScripture = (bool)request.HasScripture,
                ImmobileDescription = request.ImmobileDescription,
                ImmobileType = request.ImmobileType.ToString(),
                LocalityInfo = request.LocalityInfo,
                LocalLink = request.LocalLink,
                Neighborhood = request.Neighborhood,
                PostalCode = request.PostalCode,
                State = request.State ?? Comunication.enums.BrazilianState.SC,
                Value = request.Value ,
                Street = request.Street,
                UserCreationId = userId
            };

           

            await _repository.CreateNewImmobile(newImmobileEntity);

            return _mapper.Map<ImmobileShortResponseJson>(newImmobileEntity);
        }

        private void Validate(ImmobileRequestJson data)
        {
            var validator = new ImmobileValidator();

            var result = validator.Validate(data);

            if (!result.IsValid)
            {
                var messages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(messages);
            }
        }
    }
}