using ProvaPub.Application.UseCases.Product.ListProducts;
using ProvaPub.Infrastructure.Data.Repositories;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Product.ListProducts
{
    public class ListProductsHandlerTest(ListProductsHandlerTestFixture fixture) : IClassFixture<ListProductsHandlerTestFixture>
    {
        private readonly ListProductsHandlerTestFixture _fixture = fixture;

        [Theory(DisplayName = nameof(ShouldReturnTheCorrectResponseIfFindAllAsyncReturnsValidListProducts))]
        [Trait("Integration/UseCases", "Product - ListProducts")]
        [InlineData(15, 2, 10, 5)]
        [InlineData(30, 1, 10, 10)]
        [InlineData(5, 2, 10, 0)]
        public async Task ShouldReturnTheCorrectResponseIfFindAllAsyncReturnsValidListProducts(
            int quantity,
            int page,
            int perPage,
            int countItems)
        {
            var context = _fixture.MakeContext();

            var products = _fixture.MakeListProducts(quantity);
            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();

            var repository = new ProductRepository(context);

            var sut = new ListProductsHandler(productRepository: repository);

            var request = _fixture.MakeListProductsRequest(page: page, perPage: perPage);
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(page, response.Page);
            Assert.Equal(perPage, response.PerPage);
            Assert.Equal(countItems > perPage, response.HasNext);
            Assert.Equal(countItems, response.Items.Count);

            response.Items.ForEach(item =>
            {
                var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                Assert.NotNull(product);
                Assert.Equal(item.Name, product.Name);
                Assert.Equal(item.ProductId, product.Id);
            });
        }
    }
}