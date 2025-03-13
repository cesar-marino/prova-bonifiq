using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.UseCases.Order.PayOrder;

namespace ProvaPub.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        [HttpPost("pay")]
        public async Task<IActionResult> Pay(
            [FromBody] PayOrderRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
