using MediatR;
using ProvaPub.Application.UseCases.Order.Commons;

namespace ProvaPub.Application.UseCases.Order.PayOrder
{
    public class PayOrderRequest : IRequest<OrderResponse>
    {
    }
}
