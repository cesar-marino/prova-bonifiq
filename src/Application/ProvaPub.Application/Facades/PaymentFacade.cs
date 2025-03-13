
using ProvaPub.Application.Factories;

namespace ProvaPub.Application.Facades
{
    public class PaymentFacade(IPaymentMethodFactory paymentFactory) : IPaymentFacade
    {
        public Task Process(decimal amount, string method)
        {
            var strategy = paymentFactory.Create(method);
            strategy.Pay(amount);
            return Task.CompletedTask;
        }
    }
}
