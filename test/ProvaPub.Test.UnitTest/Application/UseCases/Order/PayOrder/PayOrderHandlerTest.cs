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
        private readonly Mock<IPaymentFacade> _paymentFacadeMock;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public PayOrderHandlerTest(PayOrderHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _paymentFacadeMock = new();
            _orderRepositoryMock = new();
            _unitOfWorkMock = new();

            _sut = new(
                paymentFacade: _paymentFacadeMock.Object,
                orderRepository: _orderRepositoryMock.Object,
                unitOfWork: _unitOfWorkMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatProcessThrows))]
        [Trait("Unit/UseCases", "Order - PayOrder")]
        public async Task ShouldRethrowSameExceptionThatProcessThrows()
        {
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
            _unitOfWorkMock
                .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakePayOrderRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }
    }
}