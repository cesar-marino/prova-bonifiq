using ProvaPub.Domain.Entities;

namespace ProvaPub.Domain.Specifications
{
    public class FirstPurchaseSpecification(IReadOnlyList<OrderEntity> orders) : ISpecification<OrderEntity>
    {
        public bool IsSatisfiedBy(OrderEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
