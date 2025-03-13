using MediatR;
using ProvaPub.Application.UseCases.Order.Commons;

namespace ProvaPub.Application.UseCases.Order.PayOrder
{
    public interface IPayOrderHandler : IRequestHandler<PayOrderRequest, OrderResponse>
    {
    }
}
