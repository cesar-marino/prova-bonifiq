using ProvaPub.Application.UseCases.Customer.ListCustomers;
using ProvaPub.Infrastructure.Data.Models;
using ProvaPub.Test.IntegrationTest.Commons;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandlerTestFixture : FixtureBase
    {
        public ListCustomersRequest MakeListCustomersRequest(int page = 1, int perPage = 10) => new(
            page: page,
            perPage: perPage);

        public List<CustomerModel> MakeListCustomers(int qty = 1)
        {
            List<CustomerModel> customers = [];
            for (int i = 0; i < qty; i++)
                customers.Add(MakeCustomerModel());

            return customers;
        }
    }
}
