using ProvaPub.Application.UseCases.Product.ListProducts;
using ProvaPub.Infrastructure.Data.Models;
using ProvaPub.Test.IntegrationTest.Commons;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Product.ListProducts
{
    public class ListProductsHandlerTestFixture : FixtureBase
    {
        public ListProductsRequest MakeListProductsRequest(int page = 1, int perPage = 10) => new(
            page: page,
            perPage: perPage);

        public List<ProductModel> MakeListProducts(int qty = 1)
        {
            List<ProductModel> products = [];
            for (int i = 0; i < qty; i++)
                products.Add(MakeProductModel());

            return products;
        }
    }
}
