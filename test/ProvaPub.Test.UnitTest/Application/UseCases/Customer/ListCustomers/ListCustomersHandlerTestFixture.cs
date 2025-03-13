using ProvaPub.Application.UseCases.Customer.ListCustomers;
using ProvaPub.Domain.Entities;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandlerTestFixture : FixtureBase
    {
        public ListCustomersRequest MakeListCustomersRequest(int? perPage = null) => new(
            page: Faker.Random.Int(),
            perPage: perPage ?? Faker.Random.Int());

        public IReadOnlyList<CustomerEntity> MakeListCustomers(int qty = 0)
        {
            List<CustomerEntity> customers = [];

            for (int i = 0; i < qty; i++)
                customers.Add(MakeCustomerEntity());

            return customers;
        }
    }
}
