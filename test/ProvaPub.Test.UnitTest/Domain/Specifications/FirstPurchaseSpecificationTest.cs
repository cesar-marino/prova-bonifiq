using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Specifications;

namespace ProvaPub.Test.UnitTest.Domain.Specifications
{
    public class FirstPurchaseSpecificationTest
    {
        [Theory(DisplayName = nameof(ShouldReturnFalseIfPurchaseAmountIsGreatherThanOneHundredReais))]
        [Trait("Unit/Specifications", "FirstPurchase")]
        [InlineData(101)]
        [InlineData(3000)]
        public void ShouldReturnFalseIfPurchaseAmountIsGreatherThanOneHundredReais(int amount)
        {
            var orders = new List<OrderEntity>();
            var order = new OrderEntity(customerId: Guid.NewGuid(), amount: amount);
            var spec = new FirstPurchaseSpecification(orders);

            var result = spec.IsSatisfiedBy(order);

            Assert.False(result);
        }

        [Theory(DisplayName = nameof(ShouldReturnTrueIfThePurchaseAmountIsLessThanOrEqualToOneHundredReais))]
        [Trait("Unit/Specifications", "FirstPurchase")]
        [InlineData(100)]
        [InlineData(99)]
        [InlineData(1)]
        public void ShouldReturnTrueIfThePurchaseAmountIsLessThanOrEqualToOneHundredReais(int amount)
        {
            var orders = new List<OrderEntity>();
            var order = new OrderEntity(customerId: Guid.NewGuid(), amount: amount);
            var spec = new FirstPurchaseSpecification(orders);

            var result = spec.IsSatisfiedBy(order);

            Assert.True(result);
        }
    }
}
