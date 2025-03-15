using AutoMapper;
using ImmobileApp.Aplication.UseCases.Immobiles.Put.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Immobiles.Put
{
    public class UpdateImmobileUseCase : IUpdateImmobileUseCase
    {
        private readonly IImmobileRepository _repository;
        public UpdateImmobileUseCase(IImmobileRepository repository)
        {
            _repository = repository;
        }
        public async Task execute(Guid userId, Guid ImmobileId, ImmobileRequestJson request)
        {
            var immobile = await _repository.GetImmobileById(ImmobileId);

            if (immobile is null)
            {
                throw new NotFoundException();
            }

            var newImmobileData = new ImmobileEntity
            {
                City = request.City ?? immobile.City,
                UpdateDate = DateTime.UtcNow,
                HasScripture = (bool)(request.HasScripture is null ? immobile.HasScripture : request.HasScripture),
                Id = ImmobileId,
                ImmobileDescription = request.ImmobileDescription ?? immobile.ImmobileDescription,
                ImmobileType = request.ImmobileType.ToString() ?? immobile.ImmobileType,
                LocalityInfo = request.LocalityInfo ?? immobile.LocalityInfo,
                LocalLink = request.LocalLink ?? immobile.LocalityInfo,
                Neighborhood = request.Neighborhood ?? immobile.Neighborhood,
                PostalCode = request.PostalCode ?? immobile.PostalCode,
                State = request.State ?? immobile.State,
                Status = request.Status.ToString() ?? immobile.Status,
                Street = request.Street ?? immobile.Street
            };

            var immobilePostalCodeAlreadyUsed = await this._repository.GetImmobileByPostalCode(request.PostalCode);

            if (immobilePostalCodeAlreadyUsed is not null)
            {
                throw new ConflictException();
            }

            await _repository.UpdateImmobile(newImmobileData);
        }
    }
}