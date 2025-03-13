using ProvaPub.Domain.Strategies;

namespace ProvaPub.Application.Factories
{
    public interface IPaymentMethodFactory
    {
        IPaymentStrategy Create(string method);
    }
}
