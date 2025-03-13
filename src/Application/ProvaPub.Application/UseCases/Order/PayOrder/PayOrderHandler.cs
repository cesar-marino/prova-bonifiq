using ProvaPub.Application.UseCases.Order.Commons;

namespace ProvaPub.Application.UseCases.Order.PayOrder
{
    public class PayOrderHandler : IPayOrderHandler
    {
        public Task<OrderResponse> Handle(PayOrderRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
