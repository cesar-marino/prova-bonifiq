using ProvaPub.Domain.Repositories;

namespace ProvaPub.Application.UseCases.Product.ListProducts
{
    public class ListProductsHandler(IProductRepository productRepository) : IListProductsHandler
    {
        public async Task<ListProductsResponse> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            _ = await productRepository.FindAllAsync(
                page: request.Page,
                perPage: request.PerPage,
                cancellationToken: cancellationToken);

            throw new NotImplementedException();
        }
    }
}
