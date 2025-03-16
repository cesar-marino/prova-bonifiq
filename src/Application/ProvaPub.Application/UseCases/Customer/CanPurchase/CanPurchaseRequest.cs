using MediatR;

namespace ProvaPub.Application.UseCases.Customer.CanPurchase
{
    public class CanPurchaseRequest(Guid customerId, decimal amount) : IRequest<bool>
    {
        public Guid CustomerId { get; } = customerId;
        public decimal Amount { get; } = amount;
    }
}
