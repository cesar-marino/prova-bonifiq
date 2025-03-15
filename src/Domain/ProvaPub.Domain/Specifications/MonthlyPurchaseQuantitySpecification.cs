using ProvaPub.Domain.Entities;

namespace ProvaPub.Domain.Specifications
{
    public class MonthlyPurchaseQuantitySpecification(IReadOnlyList<OrderEntity> orders) : ISpecification<OrderEntity>
    {
        public bool IsSatisfiedBy(OrderEntity entity)
        {
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = orders.Where(x => x.OrderDate >= baseDate);
            return !ordersInThisMonth.Any();
        }
    }
}
