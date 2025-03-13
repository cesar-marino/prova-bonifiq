using ProvaPub.Domain.Strategies;

namespace ProvaPub.Application.Factories.PaymentMethods
{
    public class PixPayment : IPaymentStrategy
    {
        public Task Pay(decimal amount)
        {
            return Task.CompletedTask;
        }
    }
}
