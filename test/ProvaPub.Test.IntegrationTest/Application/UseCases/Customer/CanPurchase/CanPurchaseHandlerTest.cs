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

        [Fact(DisplayName = nameof(ShouldReturnFalseIfItIsNotTheFirstPurchaseOfTheMonth))]
        [Trait("Integration/UseCases", "Customer - CanPurchase")]
        public async Task ShouldReturnFalseIfItIsNotTheFirstPurchaseOfTheMonth()
        {
            var context = _fixture.MakeContext();
            var customer = _fixture.MakeCustomerModel();
            var order = _fixture.MakeOrderModel();

            var customerTrackingInfo = await context.Customers.AddAsync(customer);
            var orderTrackingInfo = await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
            customerTrackingInfo.State = EntityState.Detached;
            orderTrackingInfo.State = EntityState.Detached;

            var customerRepository = new CustomerRepository(context);
            var orderRepository = new OrderRepository(context);
            var canPurchaseSpecificationFactory = new CanPurchaseSpecificationFactory();

            var sut = new CanPurchaseHandler(
                customerRepository: customerRepository,
                orderRepository: orderRepository,
                canPurcahaseSpecificationFactory: canPurchaseSpecificationFactory);

            var request = _fixture.MakeCanPurchaseRequest(customerId: customer.CustomerId);
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.False(response);
        }

        //[Theory(DisplayName = nameof(ShouldReturnFalseIfItIsNotABusinessDayAndBusinessHours))]
        //[Trait("Integration/UseCases", "Customer - CanPurchase")]
        //[InlineData(2025, 03, 16, 0, 0)]
        //public async Task ShouldReturnFalseIfItIsNotABusinessDayAndBusinessHours(int year, int month, int day, int hour, int minute)
        //{
        //    var context = _fixture.MakeContext();
        //    var customer = _fixture.MakeCustomerModel();
        //    var order = _fixture.MakeOrderModel();

        //    var customerTrackingInfo = await context.Customers.AddAsync(customer);
        //    var orderTrackingInfo = await context.Orders.AddAsync(order);
        //    await context.SaveChangesAsync();
        //    customerTrackingInfo.State = EntityState.Detached;
        //    orderTrackingInfo.State = EntityState.Detached;

        //    var customerRepository = new CustomerRepository(context);
        //    var orderRepository = new OrderRepository(context);
        //    var canPurchaseSpecificationFactory = new CanPurchaseSpecificationFactory();

        //    var sut = new CanPurchaseHandler(
        //        customerRepository: customerRepository,
        //        orderRepository: orderRepository,
        //        canPurcahaseSpecificationFactory: canPurchaseSpecificationFactory);

        //    var orderDate = new DateTime(year, month, day, hour, minute, 0);
        //    var request = _fixture.MakeCanPurchaseRequest(customerId: customer.CustomerId);
        //    var response = await sut.Handle(request, _fixture.CancellationToken);

        //    Assert.False(response);
        //}

        //[Fact(DisplayName = nameof(ShouldReturnTrueIfThePurchaseMeetsAllSpecifications))]
        //[Trait("Integration/UseCases", "Customer - CanPurchase")]
        //public async Task ShouldReturnTrueIfThePurchaseMeetsAllSpecifications()
        //{
        //    var context = _fixture.MakeContext();
        //    var customer = _fixture.MakeCustomerModel();

        //    var customerTrackingInfo = await context.Customers.AddAsync(customer);
        //    await context.SaveChangesAsync();
        //    customerTrackingInfo.State = EntityState.Detached;

        //    var customerRepository = new CustomerRepository(context);
        //    var orderRepository = new OrderRepository(context);
        //    var canPurchaseSpecificationFactory = new CanPurchaseSpecificationFactory();

        //    var sut = new CanPurchaseHandler(
        //        customerRepository: customerRepository,
        //        orderRepository: orderRepository,
        //        canPurcahaseSpecificationFactory: canPurchaseSpecificationFactory);

        //    var request = _fixture.MakeCanPurchaseRequest(customerId: customer.CustomerId, amount: 50);
        //    var response = await sut.Handle(request, _fixture.CancellationToken);

        //    Assert.True(response);
        //}
    }
}
