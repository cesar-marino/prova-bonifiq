using ProvaPub.Domain.Strategies;

namespace ProvaPub.Test.IntegrationTest.Commons
{
    public class FakePayment : IPaymentStrategy
    {
        public Task Pay(decimal amount)
        {
            Console.WriteLine($"Fake payment: {amount}");
            return Task.CompletedTask;
        }
    }
}
