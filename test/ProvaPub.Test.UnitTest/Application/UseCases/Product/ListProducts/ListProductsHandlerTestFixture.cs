using ProvaPub.Application.UseCases.Product.ListProducts;
using ProvaPub.Domain.Entities;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Product.ListProducts
{
    public class ListProductsHandlerTestFixture : FixtureBase
    {
        public ListProductsRequest MakeListProductsRequest(int? perPage = null) => new(
            page: Faker.Random.Int(),
            perPage: perPage ?? Faker.Random.Int());

        public IReadOnlyList<ProductEntity> MakeListProducts(int qty = 0)
        {
            List<ProductEntity> products = [];

            for (int i = 0; i < qty; i++)
                products.Add(MakeProductEntity());

            return products;
        }
    }
}
