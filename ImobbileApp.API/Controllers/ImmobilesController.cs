using ImmobileApp.API.Service;
using ImmobileApp.Aplication.UseCases.Immobiles.Delete.Interface;
using ImmobileApp.Aplication.UseCases.Immobiles.Get.Interfaces;
using ImmobileApp.Aplication.UseCases.Immobiles.Post.Interfaces;
using ImmobileApp.Aplication.UseCases.Immobiles.Put.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.LongResponses;
using ImmobileApp.Comunication.Responses.PaginatedResponses;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Exception;
using Microsoft.AspNetCore.Mvc;

namespace ImmobileApp.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImmobilesController : ControllerBase
    {


        [HttpPost]
        [ProducesResponseType(typeof(ImmobileShortResponseJson), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> CreateImmobleAsync([FromBody] ImmobileRequestJson request, [FromServices] ICreateImmobileUseCase useCase)
        {
            try
            {

                var token = HttpContext.Request.Headers.Authorization;

                if (token.ToString().Length < 0)
                {
                    return Unauthorized();
                }
                ;

                var authenticationContext = new AuthenticationService(HttpContext);

                var result = await useCase.execute(authenticationContext.userId(), request);
                return Created();

            }
            catch (ErrorOnValidationException e)
            {
                return BadRequest(e.getErrorMessages());
            }
            catch (UnauthorizedException e)
            {
                return Unauthorized(e.getErrorMessages());
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(ImmobilePaginatedResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAllTasks([FromQuery] PaginationParams pagParams, [FromServices] IListImmobilesUseCase useCase)
        {
            return Ok(await useCase.execute(pagParams));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ImmobileLongResponseJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindTaskById([FromHeader] Guid id, [FromServices] IGetImmobileByIdUseCase useCase)
        {
            try
            {
                var result = await useCase.execute(id);

                if (result is null)
                {
                    throw new NotFoundException();
                }

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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> EditTask([FromHeader] Guid id, [FromBody] ImmobileRequestJson request, [FromServices] IUpdateImmobileUseCase useCase)
        {
            try
            {
                var token = HttpContext.Request.Headers.Authorization;

                if (token.ToString().Length < 0)
                {
                    return Unauthorized();
                }
                ;

                var authenticationContext = new AuthenticationService(HttpContext);
                await useCase.execute(authenticationContext.userId(), id, request);
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
            catch (UnauthorizedException e)
            {
                return Unauthorized(e.getErrorMessages());
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteImmobile([FromHeader] Guid id, [FromServices] IDeleteImmobileUseCase useCase)
        {
            try
            {
                var token = HttpContext.Request.Headers.Authorization;

                if (token.ToString().Length < 0)
                {
                    return Unauthorized();
                }
                ;

                var authenticationContext = new AuthenticationService(HttpContext);
                await useCase.execute(id);
                return NoContent();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.getErrorMessages());
            }
            catch (UnauthorizedException e)
            {
                return Unauthorized(e.getErrorMessages());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}