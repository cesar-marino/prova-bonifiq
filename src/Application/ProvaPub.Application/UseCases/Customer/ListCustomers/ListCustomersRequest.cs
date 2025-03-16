using MediatR;
using ProvaPub.Application.Commons;

namespace ProvaPub.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersRequest(
        int page = 1,
        int perPage = 10) : PaginationRequest(page, perPage), IRequest<ListCustomersResponse>
    {
    }
}
