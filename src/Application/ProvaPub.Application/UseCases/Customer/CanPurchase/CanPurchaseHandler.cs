using ProvaPub.Application.Factories;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Application.UseCases.Customer.CanPurchase
{
    public class CanPurchaseHandler(
        ICustomerRepository customerRepository,
        IOrderRepository orderRepository,
        ICanPurchaseSpecificationFactory canPurcahaseSpecificationFactory) : ICanPurchaseHandler
    {
        public async Task<bool> Handle(CanPurchaseRequest request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.FindAsync(request.CustomerId, cancellationToken);
            var orders = await orderRepository.FindAllByCustomerIdAsync(customer.Id, cancellationToken);
            var specComposte = canPurcahaseSpecificationFactory.CreateOrderSpecification(orders);

            var order = new OrderEntity(
                customerId: customer.Id,
                amount: request.Amount);

            return specComposte.IsSatisfiedBy(order);
        }
    }
}
