using ProvaPub.Domain.Entities;

namespace ProvaPub.Domain.Specifications
{
    public class PurchaseAmountSpecification : ISpecification<OrderEntity>
    {
        public bool IsSatisfiedBy(OrderEntity order) => order.Amount > 0;
    }
}
