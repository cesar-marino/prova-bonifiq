using MediatR;
using ProvaPub.Application.Commons;

namespace ProvaPub.Application.UseCases.Product.ListProducts
{
    public class ListProductsRequest(
        int page,
        int perPage = 10) : PaginationRequest(page, perPage), IRequest<ListProductsResponse>
    {
    }
}
