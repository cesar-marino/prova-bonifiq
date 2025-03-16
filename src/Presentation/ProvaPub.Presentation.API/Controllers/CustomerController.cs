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
        public async Task<IActionResult> CanPurchase(
            [FromBody] CanPurchaseRequest request,
            CancellationToken cancellationToken = default)
        {
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
