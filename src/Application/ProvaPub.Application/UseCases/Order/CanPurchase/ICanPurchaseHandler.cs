using MediatR;

namespace ProvaPub.Application.UseCases.Order.CanPurchase
{
    public interface ICanPurchaseHandler : IRequestHandler<CanPurchaseRequest, bool>
    {
    }
}
