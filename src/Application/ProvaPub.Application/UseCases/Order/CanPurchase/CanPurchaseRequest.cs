using MediatR;

namespace ProvaPub.Application.UseCases.Order.CanPurchase
{
    public class CanPurchaseRequest(Guid customerId, decimal amount) : IRequest<bool>
    {
        public Guid CustomerId { get; } = customerId;
        public decimal Amount { get; } = amount;
    }
}
