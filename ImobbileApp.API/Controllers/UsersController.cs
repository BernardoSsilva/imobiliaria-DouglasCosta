using ImmobileApp.API.Service;
using ImmobileApp.Aplication.UseCases.Users.Delete.Interfaces;
using ImmobileApp.Aplication.UseCases.Users.Get.Interfaces;
using ImmobileApp.Aplication.UseCases.Users.Post.Interfaces;
using ImmobileApp.Aplication.UseCases.Users.Put.Interfaces;
using ImmobileApp.Comunication.Errors;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses;
using ImmobileApp.Comunication.Responses.LongResponses;
using ImmobileApp.Comunication.Responses.PaginatedResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Exception;
using ImmobileApp.Security.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace ImmobileApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly TokenGenerator _tokenGenerator;

        public UsersController(TokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }


        [HttpPost]
        [ProducesResponseType(typeof(UserShortResponseJson) , StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorOnValidationJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<IActionResult> CreateNewUser([FromServices] ICreateUserUseCase useCase, [FromBody] UserRequestJson body) {
            try
            {
                var result = await useCase.execute(body);
                return Created(string.Empty, result);
            }
            catch(ErrorOnValidationException e)
            {
                return BadRequest(
                 e.getErrorMessages()
                 );
               
            }
            catch(ConflictException e)
            {
                return Conflict(e.getErrorMessages());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserPaginatedResponseJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> FetchUsersWithPagination([FromServices] IListUsersWithPaginationUseCase useCase, [FromQuery] PaginationParams pagination)
        {
            var result = await useCase.execute(pagination);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserLongResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FetchUserById([FromServices] IFindUserByIdUseCase useCase, Guid id)
        {
            try
            {
                var result = await useCase.execute(id);
                return Ok(result);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.getErrorMessages());
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateUser([FromServices] IUpdateUserUseCase useCase, [FromBody] UserRequestJson body, Guid id)
        {
            if (HttpContext.Request.Headers.Authorization.ToString().Length <= 0)
            {
                return Unauthorized();
            }
            try
            {
                var authenticationContext = new AuthenticationService(HttpContext);
                Console.Write(authenticationContext.userId());
                await useCase.execute(body, id);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.getErrorMessages());
            }
            catch (ConflictException e)
            {
                return Conflict(e.getErrorMessages());
            }
            catch(ErrorOnValidationException e)
            {
                return BadRequest(
                    e.getErrorMessages()  
                );
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteUser([FromServices] IDeleteUserUseCase useCase, Guid id)
        {
            if (HttpContext.Request.Headers.Authorization.ToString() is null )
            {
                return Unauthorized();
            }
            try
            {
                await useCase.execute(id);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.getErrorMessages());
            }
        }


        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthenticationResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromServices] ILoginUseCase useCase, AuthenticationRequestJson request)
        {
            try
            {
                var result = await useCase.execute(request);
                var token = _tokenGenerator.Generate(result);

                return Ok(new AuthenticationResponseJson
                {
                    Token = token,
                    User = result
                });
            } catch
            {
                return Unauthorized();
            }
        }
    }
}
