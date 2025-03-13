using ProvaPub.Domain.Strategies;

namespace ProvaPub.Infrastructure.Payment
{
    public class PixPayment : IPaymentStrategy
    {
        public Task Pay(decimal amount)
        {
            Console.WriteLine($"Pix payment: {amount}");
            return Task.CompletedTask;
        }
    }
}
