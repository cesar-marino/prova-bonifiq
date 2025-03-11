using MediatR;

namespace ProvaPub.Application.UseCases.Product.ListProducts
{
    public interface IListProductsHandler : IRequestHandler<ListProductsRequest, ListProductsResponse>
    {
    }
}
