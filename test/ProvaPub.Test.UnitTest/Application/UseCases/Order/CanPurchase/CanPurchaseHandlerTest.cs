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
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ICanPurchaseSpecificationFactory> _specificationFactoryMock;

        public CanPurchaseHandlerTest(CanPurchaseHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _customerRepositoryMock = new();
            _orderRepositoryMock = new();
            _specificationFactoryMock = new();

            _sut = new(
                customerRepository: _customerRepositoryMock.Object,
                orderRepository: _orderRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAsyncThrows))]
        [Trait("Unit/UseCases", "Customer - CanPurchase")]
        public async Task ShouldRethrowSameExceptionThatFindAsyncThrows()
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

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAllByCustomerIdAsyncThrows))]
        [Trait("Unit/UseCases", "Customer - CanPurchase")]
        public async Task ShouldRethrowSameExceptionThatFindAllByCustomerIdAsyncThrows()
        {
            var customer = _fixture.MakeCustomerEntity();
            _customerRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(customer);

            _orderRepositoryMock
                .Setup(x => x.FindAllByCustomerIdAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeCanPurchaseRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }
    }
}
