using Microsoft.EntityFrameworkCore;
using ProvaPub.Application.Facades;
using ProvaPub.Application.Factories;
using ProvaPub.Application.UseCases.Order.PayOrder;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Repositories;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Order.PayOrder
{
    public class PayOrderHandlerTest(PayORderHandlerTestFixture fixture) : IClassFixture<PayORderHandlerTestFixture>
    {
        private readonly PayORderHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldThrowNotFoundExceptionIfPaymentMethodNotFound))]
        [Trait("Integration/UseCases", "Order - PayOrder")]
        public async Task ShouldThrowNotFoundExceptionIfPaymentMethodNotFound()
        {
            var context = _fixture.MakeContext();
            var customerModel = _fixture.MakeCustomerModel();
            var trackingInfo = await context.Customers.AddAsync(customerModel);
            await context.SaveChangesAsync();
            trackingInfo.State = EntityState.Detached;

            var unitOfWork = new UnitOfWork(context);
            var paymentFacory = new PaymentMethodFactory();
            var paymentFacade = new PaymentFacade(paymentFacory);
            var customerRepository = new CustomerRepository(context);
            var orderRepository = new OrderRepository(context);

            var sut = new PayOrderHandler(
                customerRepository: customerRepository,
                paymentFacade,
                orderRepository: orderRepository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakePayOrderRequest(customerId: customerModel.CustomerId);
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Payment method not found", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldReturnTheCorrectResponseIfOrderIsPaidSuccessfully))]
        [Trait("Integration/UseCases", "Order - PayOrder")]
        public async Task ShouldReturnTheCorrectResponseIfOrderIsPaidSuccessfully()
        {
            var context = _fixture.MakeContext();
            var customerModel = _fixture.MakeCustomerModel();
            var trackingInfo = await context.Customers.AddAsync(customerModel);
            await context.SaveChangesAsync();
            trackingInfo.State = EntityState.Detached;

            var unitOfWork = new UnitOfWork(context);
            var paymentFacory = new PaymentMethodFactory();
            var paymentFacade = new PaymentFacade(paymentFacory);
            var customerRepository = new CustomerRepository(context);
            var orderRepository = new OrderRepository(context);

            var sut = new PayOrderHandler(
                customerRepository: customerRepository,
                paymentFacade,
                orderRepository: orderRepository,
                unitOfWork: unitOfWork);

            var request = _fixture.MakePayOrderRequest(customerId: customerModel.CustomerId, paymentMathod: "pix");
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(request.Amount, response.Amount);
            Assert.Equal(request.CustomerId, response.Customer.CustomerId);
        }
    }
}
