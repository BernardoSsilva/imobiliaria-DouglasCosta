using System.Threading.Tasks;
using dotenv.net;
using ImmobileApp.API.Service;
using ImmobileApp.Aplication.UseCases.Images.Delete.Interfaces;
using ImmobileApp.Aplication.UseCases.Images.Post.Interfaces;
using ImmobileApp.Comunication.Requests;
using ImmobileApp.Comunication.Responses.ShortResponses;
using ImmobileApp.Domain.Entities;
using ImmobileApp.Exception;
using Microsoft.AspNetCore.Mvc;

namespace ImmobileApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost("/{immobileId}/create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateImage([FromServices] ICreateImageUseCase useCase, [FromForm] ImageRequestJson requestData, string immobileId)
        {

            try
            {
                DotNetEnv.Env.Load();
                string cloudnaryUrl = Environment.GetEnvironmentVariable("CLOUDINARY_URL");
                var token = HttpContext.Request.Headers.Authorization;

                if (token.ToString().Length < 0)
                {
                    return Unauthorized();
                }
                var result = await useCase.Execute(requestData, cloudnaryUrl, immobileId);

                return Created();

            }
            catch (NotFoundException ex)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("/{imageId}/delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteImage([FromServices] IDeleteImageUseCase useCase, Guid imageId)
        {
            try
            {
                DotNetEnv.Env.Load();
                string cloudnaryUrl = Environment.GetEnvironmentVariable("CLOUDINARY_URL");
                var token = HttpContext.Request.Headers.Authorization;

                if (token.ToString().Length < 0)
                {
                    return Unauthorized();
                }
                var result = await useCase.DeleteImage(imageId, cloudnaryUrl);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
