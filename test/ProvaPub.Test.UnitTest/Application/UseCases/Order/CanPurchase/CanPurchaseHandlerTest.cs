using Moq;
using ProvaPub.Application.Factories;
using ProvaPub.Application.UseCases.Order.CanPurchase;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Order.CanPurchase
{
    public class CanPurchaseHandlerTest : IClassFixture<CanPurchaseHandlerTestFixture>
    {
        private readonly CanPurchaseHandlerTestFixture _fixture;
        private readonly CanPurchaseHandler _sut;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<ICanPurchaseSpecificationFactory> _specificationFactoryMock;

        public CanPurchaseHandlerTest(CanPurchaseHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _customerRepositoryMock = new();
            _specificationFactoryMock = new();

            _sut = new(customerRepository: _customerRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldReturnSameExceptionThatFindAsyncThrows))]
        [Trait("Unit/UseCases", "Customer - CanPurchase")]
        public async Task ShouldReturnSameExceptionThatFindAsyncThrows()
        {
            _customerRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFoundException("Customer"));

            var request = _fixture.MakeCanPurchaseRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Customer not found", exception.Message);
        }
    }
}
