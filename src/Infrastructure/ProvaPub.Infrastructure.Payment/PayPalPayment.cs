using ProvaPub.Domain.Strategies;

namespace ProvaPub.Infrastructure.Payment
{
    public class PayPalPayment : IPaymentStrategy
    {
        public Task Pay(decimal amount)
        {
            Console.WriteLine($"PayPal payment: {amount}");
            return Task.CompletedTask;
        }
    }
}
