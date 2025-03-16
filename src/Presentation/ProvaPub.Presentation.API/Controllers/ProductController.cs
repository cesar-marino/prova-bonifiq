using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProvaPub.Application.UseCases.Product.ListProducts;

namespace ProvaPub.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        [HttpGet("list")]
        public async Task<IActionResult> List(
            [FromQuery] int page,
            [FromQuery] int? perPage = null,
            CancellationToken cancellationToken = default)
        {
            var request = new ListProductsRequest(page: page);

            if (perPage != null)
                request.PerPage = perPage.Value;

            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
    }
}
