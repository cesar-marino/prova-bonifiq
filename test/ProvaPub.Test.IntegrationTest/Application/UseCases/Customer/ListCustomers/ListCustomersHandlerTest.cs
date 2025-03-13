using ProvaPub.Application.UseCases.Customer.ListCustomers;
using ProvaPub.Infrastructure.Data.Repositories;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandlerTest(ListCustomersHandlerTestFixture fixture) : IClassFixture<ListCustomersHandlerTestFixture>
    {
        private readonly ListCustomersHandlerTestFixture _fixture = fixture;

        [Theory(DisplayName = nameof(ShouldReturnTheCorrectResponseIfFindAllAsyncReturnsValidListCustomers))]
        [Trait("Integration/UseCases", "Customer - ListCustomers")]
        [InlineData(15, 2, 10, 5)]
        [InlineData(30, 1, 10, 10)]
        [InlineData(5, 2, 10, 0)]
        public async Task ShouldReturnTheCorrectResponseIfFindAllAsyncReturnsValidListCustomers(
            int quantity,
            int page,
            int perPage,
            int countItems)
        {
            var context = _fixture.MakeContext();

            var customers = _fixture.MakeListCustomers(quantity);
            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();

            var repository = new CustomerRepository(context);

            var sut = new ListCustomersHandler(customerRepository: repository);

            var request = _fixture.MakeListCustomersRequest(page: page, perPage: perPage);
            var response = await sut.Handle(request, _fixture.CancellationToken);

            Assert.Equal(page, response.Page);
            Assert.Equal(perPage, response.PerPage);
            Assert.Equal(countItems > perPage, response.HasNext);
            Assert.Equal(countItems, response.Items.Count);

            response.Items.ForEach(item =>
            {
                var customer = customers.FirstOrDefault(x => x.Id == item.CustomerId);
                Assert.NotNull(customer);
                Assert.Equal(item.Name, customer.Name);
                Assert.Equal(item.CustomerId, customer.Id);
            });
        }
    }
}
