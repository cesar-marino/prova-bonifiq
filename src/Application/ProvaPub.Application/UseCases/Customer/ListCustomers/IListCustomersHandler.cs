using MediatR;

namespace ProvaPub.Application.UseCases.Customer.ListCustomers
{
    public interface IListCustomersHandler : IRequestHandler<ListCustomersRequest, ListCustomersResponse>
    {
    }
}
