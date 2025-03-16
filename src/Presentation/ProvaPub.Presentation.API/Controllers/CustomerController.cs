using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.UseCases.Customer.CanPurchase;
using ProvaPub.Application.UseCases.Customer.ListCustomers;

namespace ProvaPub.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        [HttpGet("list")]
        [ProducesResponseType(typeof(ListCustomersResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List(
            [FromQuery] int page,
            [FromQuery] int? perPage = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ListCustomersRequest(page: page);
            if (perPage != null)
                request.PerPage = perPage.Value;

            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }

        [HttpGet("can_purchase")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CanPurchase(
            [FromQuery] Guid customerId,
            [FromQuery] decimal amount,
            CancellationToken cancellationToken = default)
        {
            var request = new CanPurchaseRequest(customerId: customerId, amount: amount);
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
