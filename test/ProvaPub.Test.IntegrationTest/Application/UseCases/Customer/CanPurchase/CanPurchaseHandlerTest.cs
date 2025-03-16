using Microsoft.EntityFrameworkCore;
using ProvaPub.Application.Factories;
using ProvaPub.Application.UseCases.Customer.CanPurchase;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Infrastructure.Data.Repositories;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Customer.CanPurchase
{
    public class CanPurchaseHandlerTest(CanPurchaseHandlerTestFixture fixture) : IClassFixture<CanPurchaseHandlerTestFixture>
    {
        private readonly CanPurchaseHandlerTestFixture _fixture = fixture;

        [Fact(DisplayName = nameof(ShouldThrowNotFoundExceptionIfCustomerNotFound))]
        [Trait("Integration/UseCases", "Customer - CanPurchase")]
        public async Task ShouldThrowNotFoundExceptionIfCustomerNotFound()
        {
            var context = _fixture.MakeContext();
            var customerRepository = new CustomerRepository(context);
            var orderRepository = new OrderRepository(context);
            var canPurchaseSpecificationFactory = new CanPurchaseSpecificationFactory();

            var sut = new CanPurchaseHandler(
                customerRepository: customerRepository,
                orderRepository: orderRepository,
                canPurcahaseSpecificationFactory: canPurchaseSpecificationFactory);

            var request = _fixture.MakeCanPurchaseRequest();
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Customer not found", exception.Message);
        }

        [Theory(DisplayName = nameof(ShouldReturnFalseIfAmountIsInvalid))]
        [Trait("Integration/UseCases", "Customer - CanPurchase")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-15.07)]
        public async Task ShouldReturnFalseIfAmountIsInvalid(decimal amount)
        {
            var context = _fixture.MakeContext();
            var customer = _fixture.MakeCustomerModel();

            var trackingInfo = await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            trackingInfo.State = EntityState.Detached;

            var customerRepository = new CustomerRepository(context);
            var orderRepository = new OrderRepository(context);
            var canPurchaseSpecificationFactory = new CanPurchaseSpecificationFactory();

            var sut = new CanPurchaseHandler(
                customerRepository: customerRepository,
                orderRepository: orderRepository,
                canPurcahaseSpecificationFactory: canPurchaseSpecificationFactory);

            var request = _fixture.MakeCanPurchaseRequest(customerId: customer.CustomerId, amount: amount);
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.False(response);
        }

        [Theory(DisplayName = nameof(ShouldReturnFalseIfTheAmountOfTheFirstPurchaseIsGreaterThatnOneHundredReais))]
        [Trait("Integration/UseCases", "Customer - CanPurchase")]
        [InlineData(101)]
        [InlineData(1000)]
        public async Task ShouldReturnFalseIfTheAmountOfTheFirstPurchaseIsGreaterThatnOneHundredReais(decimal amount)
        {
            var context = _fixture.MakeContext();
            var customer = _fixture.MakeCustomerModel();

            var trackingInfo = await context.Customers.AddAsync(customer);
            await context.SaveChangesAsync();
            trackingInfo.State = EntityState.Detached;

            var customerRepository = new CustomerRepository(context);
            var orderRepository = new OrderRepository(context);
            var canPurchaseSpecificationFactory = new CanPurchaseSpecificationFactory();

            var sut = new CanPurchaseHandler(
                customerRepository: customerRepository,
                orderRepository: orderRepository,
                canPurcahaseSpecificationFactory: canPurchaseSpecificationFactory);

            var request = _fixture.MakeCanPurchaseRequest(customerId: customer.CustomerId, amount: amount);
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.False(response);
        }
    }
}
