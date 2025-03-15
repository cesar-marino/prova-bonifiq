using ProvaPub.Domain.Entities;

namespace ProvaPub.Domain.Specifications
{
    public class PurchaseDateSpecification : ISpecification<OrderEntity>
    {
        public bool IsSatisfiedBy(OrderEntity order)
        {
            return !(order.OrderDate.Hour < 8
                || order.OrderDate.Hour > 18
                || order.OrderDate.DayOfWeek == DayOfWeek.Saturday
                || order.OrderDate.DayOfWeek == DayOfWeek.Sunday);
        }
    }
}
