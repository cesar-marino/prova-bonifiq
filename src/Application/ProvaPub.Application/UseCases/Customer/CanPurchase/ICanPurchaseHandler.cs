using MediatR;

namespace ProvaPub.Application.UseCases.Customer.CanPurchase
{
    public interface ICanPurchaseHandler : IRequestHandler<CanPurchaseRequest, bool>
    {
    }
}
