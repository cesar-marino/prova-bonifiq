using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Specifications;

namespace ProvaPub.Test.UnitTest.Domain.Specifications
{
    public class PurchaseDateSpecificationTest
    {
        [Theory(DisplayName = nameof(ShouldReturnFalseIfItIsNotBusinessHours))]
        [Trait("Unit/Specification", "PurchaseDate")]
        [InlineData(18, 0)]
        [InlineData(0, 0)]
        [InlineData(7, 0)]
        [InlineData(7, 59)]
        public void ShouldReturnFalseIfItIsNotBusinessHours(int hour, int minute)
        {
            var date = new DateTime(
                year: DateTime.UtcNow.Year,
                month: DateTime.UtcNow.Month,
                day: DateTime.UtcNow.Day,
                hour: hour,
                minute: minute,
                second: 0);

            var order = new OrderEntity(customerId: Guid.NewGuid(), amount: 1, orderDate: date);
            var spec = new PurchaseDataSpecification();

            var result = spec.IsSatisfiedBy(order);

            Assert.False(result);
        }
        
        [Theory(DisplayName = nameof(ShouldReturnFalseIfItIsNotBusinessDay))]
        [Trait("Unit/Specification", "PurchaseDate")]
        [InlineData(15)]
        [InlineData(16)]
        [InlineData(22)]
        [InlineData(23)]
        public void ShouldReturnFalseIfItIsNotBusinessDay(int day)
        {
            var date = new DateTime(
                year: 2025,
                month: 3,
                day: day,
                hour: 8,
                minute: 0,
                second: 0);

            var order = new OrderEntity(customerId: Guid.NewGuid(), amount: 1, orderDate: date);
            var spec = new PurchaseDataSpecification();

            var result = spec.IsSatisfiedBy(order);

            Assert.False(result);
        }
    }
}
