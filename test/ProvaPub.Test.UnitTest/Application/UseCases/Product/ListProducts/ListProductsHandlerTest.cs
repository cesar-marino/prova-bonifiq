using Moq;
using ProvaPub.Application.UseCases.Product.ListProducts;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Product.ListProducts
{
    public class ListProductsHandlerTest : IClassFixture<ListProductsHandlerTestFixture>
    {
        private readonly ListProductsHandlerTestFixture _fixture;
        private readonly ListProductsHandler _sut;
        private readonly Mock<IProductRepository> _productRepositoryMock;

        public ListProductsHandlerTest(ListProductsHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _productRepositoryMock = new();

            _sut = new(productRepository: _productRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAllAsyncThrows))]
        [Trait("Unit/UseCases", "Product - ListProducts")]
        public async Task ShouldRethrowSameExceptionThatFindAllAsyncThrows()
        {
            _productRepositoryMock
                .Setup(x => x.FindAllAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeListProductsRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }

        [Theory(DisplayName = nameof(ShouldReturnTheCorrectResponseIfFindAllAsyncReturnsListProducts))]
        [Trait("Unit/UseCases", "Product - ListProducts")]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public async Task ShouldReturnTheCorrectResponseIfFindAllAsyncReturnsListProducts(int quantity)
        {
            var products = _fixture.MakeListProducts(quantity);
            _productRepositoryMock
                .Setup(x => x.FindAllAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(products);

            var request = _fixture.MakeListProductsRequest();
            var response = await _sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(request.Page, response.Page);
            Assert.Equal(request.PerPage, response.PerPage);
            Assert.Equal(products.Count, response.Items.Count);
            response.Items.ForEach(item =>
            {
                var product = products.FirstOrDefault(x => x.Id == item.ProductId);
                Assert.NotNull(product);
                Assert.Equal(product.Id, item.ProductId);
                Assert.Equal(product.Name, item.Name);
            });
        }
    }
}
