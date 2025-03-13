namespace ProvaPub.Domain.Strategies
{
    public interface IPaymentStrategy
    {
        Task Pay(decimal amount);
    }
}
