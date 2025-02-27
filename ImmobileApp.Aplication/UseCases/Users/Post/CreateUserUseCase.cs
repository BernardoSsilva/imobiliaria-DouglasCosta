using AutoMapper;
using ImmobileApp.Aplication.UseCases.Users.Post.Interfaces;
using ImmobileApp.Aplication.Validators;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Users.Post
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserUseCase(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


       public async Task<UserShortResponseJson> execute(UserRequestJson data)
        {

           var encriptedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);

           Validate(data);

            var userAlreadyExists = _repository.GetUserByEmail(data.UserEmail);

            if(userAlreadyExists != null)
            {
                throw new ConflictException("User email already registered");
            }

           var entity = _mapper.Map<UserEntity>(data);
            entity.Password = encriptedPassword;
            await _repository.CreateNewUser(entity);

            return _mapper.Map<UserShortResponseJson>(entity);
        }



        private void Validate(UserRequestJson data)
        {
            var validator = new UserValidator();
            var result = validator.Validate(data);

            if (!result.IsValid)
            {
                var messages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(messages);
            }
        }
    }
}
