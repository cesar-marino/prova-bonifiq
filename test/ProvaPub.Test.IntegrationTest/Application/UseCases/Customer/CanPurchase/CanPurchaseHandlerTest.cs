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

            var request = _fixture.MakeCanPurchaseRequest(amount: 101);
            var act = () => sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<NotFoundException>(act);
            Assert.Equal("not-found", exception.Code);
            Assert.Equal("Customer not found", exception.Message);
        }
    }
}
