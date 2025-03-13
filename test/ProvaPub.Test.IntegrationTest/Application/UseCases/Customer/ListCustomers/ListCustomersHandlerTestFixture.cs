using ProvaPub.Application.UseCases.Customer.ListCustomers;
using ProvaPub.Domain.Entities;
using ProvaPub.Test.IntegrationTest.Commons;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandlerTestFixture : FixtureBase
    {
        public ListCustomersRequest MakeListCustomersRequest(int page = 1, int perPage = 10) => new(
            page: page,
            perPage: perPage);

        public List<CustomerEntity> MakeListCustomers(int qty = 1)
        {
            List<CustomerEntity> customers = [];
            for (int i = 0; i < qty; i++)
                customers.Add(MakeCustomerEntity());

            return customers;
        }
    }
}
