using ProvaPub.Application.UseCases.Product.ListProducts;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Product.ListProducts
{
    public class ListProductsHandlerTestFixture : FixtureBase
    {
        public ListProductsRequest MakeListProductsRequest() => new(page: Faker.Random.Int(), perPage: Faker.Random.Int());
    }
}
