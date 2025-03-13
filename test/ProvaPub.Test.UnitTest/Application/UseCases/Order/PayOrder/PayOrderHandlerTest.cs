using Moq;
using ProvaPub.Application.Facades;
using ProvaPub.Application.UseCases.Order.PayOrder;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Order.PayOrder
{
    public class PayOrderHandlerTest : IClassFixture<PayOrderHandlerTestFixture>
    {
        private readonly PayOrderHandlerTestFixture _fixture;
        private readonly PayOrderHandler _sut;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly Mock<IPaymentFacade> _paymentFacadeMock;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public PayOrderHandlerTest(PayOrderHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _customerRepositoryMock = new();
            _paymentFacadeMock = new();
            _orderRepositoryMock = new();
            _unitOfWorkMock = new();

            _sut = new(
                customerRepository: _customerRepositoryMock.Object,
                paymentFacade: _paymentFacadeMock.Object,
                orderRepository: _orderRepositoryMock.Object,
                unitOfWork: _unitOfWorkMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAsyncCustomerThrows))]
        [Trait("Unit/UseCases", "Order - PayOrder")]
        public async Task ShouldRethrowSameExceptionThatFindAsyncCustomerThrows()
        {
            _customerRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new NotFoundException("Customer"));

            var request = _fixture.MakePayOrderRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Customer not found", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatProcessThrows))]
        [Trait("Unit/UseCases", "Order - PayOrder")]
        public async Task ShouldRethrowSameExceptionThatProcessThrows()
        {
            var customer = _fixture.MakeCustomerEntity();
            _customerRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(customer);

            _paymentFacadeMock
                .Setup(x => x.Process(
                    It.IsAny<decimal>(),
                    It.IsAny<string>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakePayOrderRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatInsertAsyncThrows))]
        [Trait("Unit/UseCases", "Order - PayOrder")]
        public async Task ShouldRethrowSameExceptionThatInsertAsyncThrows()
        {
            var customer = _fixture.MakeCustomerEntity();
            _customerRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(customer);

            _orderRepositoryMock
                .Setup(x => x.InsertAsync(
                    It.IsAny<OrderEntity>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakePayOrderRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCommitAsyncThrows))]
        [Trait("Unit/UseCases", "Order - PayOrder")]
        public async Task ShouldRethrowSameExceptionThatCommitAsyncThrows()
        {
            var customer = _fixture.MakeCustomerEntity();
            _customerRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(customer);

            _unitOfWorkMock
                .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakePayOrderRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldReturnTheCorrectResponseIfOrderIsPaidSuccessfully))]
        [Trait("Unit/UseCases", "Order - PayOrder")]
        public async Task ShouldReturnTheCorrectResponseIfOrderIsPaidSuccessfully()
        {
            var customer = _fixture.MakeCustomerEntity();
            _customerRepositoryMock
                .Setup(x => x.FindAsync(
                    It.IsAny<Guid>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(customer);

            var request = _fixture.MakePayOrderRequest();
            var response = await _sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(request.Amount, response.Amount);
            Assert.Equal(customer.Id, response.Customer.CustomerId);
            Assert.Equal(customer.Name, response.Customer.Name);
        }
    }
}