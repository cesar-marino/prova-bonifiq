using ProvaPub.Domain.Entities;

namespace ProvaPub.Domain.Specifications
{
    public class PurchaseDataSpecification : ISpecification<OrderEntity>
    {
        public bool IsSatisfiedBy(OrderEntity entity)
        {
            return !(DateTime.UtcNow.Hour < 8
                || DateTime.UtcNow.Hour > 18
                || DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday
                || DateTime.UtcNow.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}
