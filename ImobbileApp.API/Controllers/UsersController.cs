using ImmobileApp.Aplication.UseCases.Users.Post.Interfaces;
using ImmobileApp.Comunication.Errors;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ImmobileApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

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
                return BadRequest(new ErrorOnValidationJson
                {
                    Messages = e.getErrorMessages(),
                    StatusCode = e.getStatusCode()
                });
               
            }
            catch(ConflictException e)
            {
                return Conflict(e.Message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
