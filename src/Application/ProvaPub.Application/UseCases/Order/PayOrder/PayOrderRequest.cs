using MediatR;
using ProvaPub.Application.UseCases.Order.Commons;

namespace ProvaPub.Application.UseCases.Order.PayOrder
{
    public class PayOrderRequest(
        Guid customerId,
        string paymentMethod,
        decimal amount) : IRequest<OrderResponse>
    {
        public Guid CustomerId { get; } = customerId;
        public string PaymentMethod { get; } = paymentMethod;
        public decimal Amount { get; } = amount;
    }
}
