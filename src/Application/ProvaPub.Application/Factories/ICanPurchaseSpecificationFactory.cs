using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Specifications;

namespace ProvaPub.Application.Factories
{
    public interface ICanPurchaseSpecificationFactory
    {
        CompositeSpecification<OrderEntity> CreateOrderSpecification(IReadOnlyList<OrderEntity> orders);
    }
}
