
using ProvaPub.Application.UseCases.Customer.Commons;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandler(ICustomerRepository customerRepository) : IListCustomersHandler
    {
        public async Task<ListCustomersResponse> Handle(ListCustomersRequest request, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.FindAllAsync(
                page: request.Page,
                perPage: request.PerPage,
                cancellationToken);

            return new(
                page: request.Page,
                perPage: request.PerPage,
                hasNext: customers.Count > request.PerPage,
                items: [.. customers.Select(x => CustomerResponse.FromEntity(x))]);
        }
    }
}
