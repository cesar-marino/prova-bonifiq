using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Specifications;

namespace ProvaPub.Test.UnitTest.Domain.Specifications
{
    public class MonthlyPurchaseQuantitySpecificationTest
    {
        [Fact(DisplayName = nameof(ShouldReturnFalseIfItIsNotTheFirstPurchaseOfTheMonth))]
        [Trait("Unit/Specifications", "MonthlyPurchaseQuantity")]
        public void ShouldReturnFalseIfItIsNotTheFirstPurchaseOfTheMonth()
        {
            var orders = new List<OrderEntity>() { new(customerId: Guid.NewGuid(), amount: 50) };
            var order = new OrderEntity(customerId: Guid.NewGuid(), amount: 90);
            var spec = new MonthlyPurchaseQuantitySpecification(orders);

            var result = spec.IsSatisfiedBy(order);

            Assert.False(result);
        }
    }
}
