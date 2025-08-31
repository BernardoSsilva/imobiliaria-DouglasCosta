using AutoMapper;
using ImmobileApp.Aplication.UseCases.Users.Put.Interfaces;
using ImmobileApp.Aplication.Validators;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;


namespace ImmobileApp.Aplication.UseCases.Users.Put
{
    public class UpdateUserUseCase : IUpdateUserUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UpdateUserUseCase(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task execute(UserRequestJson body, Guid userId)
        {
            var user = await _repository.GetUserById(userId);

            if (user is null) throw new NotFoundException();


            var userWithEmail = await _repository.GetUserByEmail(body.UserEmail);

            if (userWithEmail!= null && userWithEmail.Id != userId) throw new ConflictException();

            try
            {
                var newEntity = new UserEntity
                {
                    Id = userId,
                    UserEmail = body.UserEmail.Length > 0 ? body.UserEmail : user.UserEmail,
                    BornDate = body.BornDate ?? user.BornDate,
                    Role = body.Role is null ? user.Role : body.Role.ToString(),
                    Phone = body.Phone.Length > 0 ? body.Phone : user.Phone,
                    UserName = body.UserName.Length > 0 ? body.UserName : user.UserName,
                };


                await _repository.UpdateUser(newEntity);
            }
            catch
            {
                throw new System.Exception("Unknown Error");
            }
        }

        private void Validate(UserRequestJson request)
        {
            var validator = new UserValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
