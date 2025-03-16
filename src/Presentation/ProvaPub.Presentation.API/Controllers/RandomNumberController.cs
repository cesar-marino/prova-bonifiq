using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.UseCases.RandomNumber.Commons;
using ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber;

namespace ProvaPub.Presentation.API.Controllers
{
    [Route("random_number")]
    [ApiController]
    public class RandomNumberController(IMediator mediator) : ControllerBase
    {
        [HttpGet("generate")]
        [ProducesResponseType(typeof(RandomNumberResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Generate(CancellationToken cancellationToken = default)
        {
            var request = new GenerateRandomNumberRequest();
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
