using ProvaPub.Application.Commons;
using ProvaPub.Application.UseCases.Customer.Commons;

namespace ProvaPub.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersResponse(
        int page,
        int perPage,
        bool hasNext,
        List<CustomerResponse> items) : PaginationResponse<CustomerResponse>(
            page,
            perPage,
            hasNext,
            items)
    {
    }
}
