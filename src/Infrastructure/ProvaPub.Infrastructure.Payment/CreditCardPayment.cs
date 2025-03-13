using ProvaPub.Domain.Strategies;

namespace ProvaPub.Infrastructure.Payment
{
    public class CreditCardPayment : IPaymentStrategy
    {
        public Task Pay(decimal amount)
        {
            Console.WriteLine($"Credit Card payment: {amount}");
            return Task.CompletedTask;
        }
    }
}
