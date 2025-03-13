
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandler(ICustomerRepository customerRepository) : IListCustomersHandler
    {
        public async Task<ListCustomersResponse> Handle(ListCustomersRequest request, CancellationToken cancellationToken)
        {
            _ = await customerRepository.FindAllAsync(page: request.Page, perPage: request.PerPage);
            throw new NotImplementedException();
        }
    }
}
