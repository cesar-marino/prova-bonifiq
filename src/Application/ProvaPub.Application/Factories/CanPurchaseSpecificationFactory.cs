using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Specifications;

namespace ProvaPub.Application.Factories
{
    public class CanPurchaseSpecificationFactory : ICanPurchaseSpecificationFactory
    {
        public CompositeSpecification<OrderEntity> CreateOrderSpecification(IReadOnlyList<OrderEntity> orders)
        {
            var compositeSpec = new CompositeSpecification<OrderEntity>();

            compositeSpec.AddSpecification(new FirstPurchaseSpecification(orders));
            compositeSpec.AddSpecification(new MonthlyPurchaseQuantitySpecification(orders));
            compositeSpec.AddSpecification(new PurchaseAmountSpecification());
            compositeSpec.AddSpecification(new PurchaseDateSpecification());

            return compositeSpec;
        }
    }
}
