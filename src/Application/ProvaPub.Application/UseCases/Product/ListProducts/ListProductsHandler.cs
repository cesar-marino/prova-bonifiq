using ProvaPub.Application.UseCases.Product.Commons;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Application.UseCases.Product.ListProducts
{
    public class ListProductsHandler(IProductRepository productRepository) : IListProductsHandler
    {
        public async Task<ListProductsResponse> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await productRepository.FindAllAsync(
                page: request.Page,
                perPage: request.PerPage,
                cancellationToken: cancellationToken);

            return new ListProductsResponse(
                page: request.Page,
                perPage: request.PerPage,
                hasNext: products.Count < request.PerPage,
                items: [.. products.Select(ProductResponse.FromEntity)]);
        }
    }
}
