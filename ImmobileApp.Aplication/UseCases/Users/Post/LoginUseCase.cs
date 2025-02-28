using AutoMapper;
using ImmobileApp.Aplication.UseCases.Users.Post.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Repositories;
using ImmobileApp.Exception;

namespace ImmobileApp.Aplication.UseCases.Users.Post
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public LoginUseCase(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserShortResponseJson> execute(AuthenticationRequestJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);
            if(user == null)
            {
                throw new UnauthorizedException();
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                throw new UnauthorizedException();
            }

            return _mapper.Map<UserShortResponseJson>(user);

        }
    }
}
