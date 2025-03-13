using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Strategies;
using System.Reflection;

namespace ProvaPub.Application.Factories
{
    public class PaymentMethodFactory : IPaymentMethodFactory
    {
        public IPaymentStrategy Create(string method)
        {
            var paymentMethods = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IPaymentStrategy).IsAssignableFrom(t) && !t.IsInterface)
                .ToDictionary(t => t.Name.ToLower().Replace("payment", ""), t => t);

            if (paymentMethods.TryGetValue(method.ToLower(), out var paymentType))
                return (IPaymentStrategy)Activator.CreateInstance(paymentType)!;

            throw new NotFoundException("Payment method");
        }
    }
}
