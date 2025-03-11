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
    }
}
