using ProvaPub.Application.UseCases.Customer.ListCustomers;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandlerTestFixture : FixtureBase
    {
        public ListCustomersRequest MakeListCustomersRequest() => new(
            page: Faker.Random.Int(),
            perPage: Faker.Random.Int());
    }
}
