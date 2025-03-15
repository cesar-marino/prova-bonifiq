using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Specifications;

namespace ProvaPub.Test.UnitTest.Domain.Specifications
{
    public class PurchaseAmountSpecificationTest
    {
        [Theory(DisplayName = nameof(ShouldReturnFalseIfAmountIsInvalid))]
        [Trait("Unit/Specifications", "PurchaseAmount")]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-15.73)]
        public void ShouldReturnFalseIfAmountIsInvalid(decimal amount)
        {
            var order = new OrderEntity(customerId: Guid.NewGuid(), amount: amount);
            var spec = new PurchaseAmountSpecification();

            var result = spec.IsSatisfiedBy(order);

            Assert.False(result);
        }
    }
}
