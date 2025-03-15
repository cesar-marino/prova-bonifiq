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
            var spec = new PurchaseDateSpecification();

            var result = spec.IsSatisfiedBy(order);

            Assert.False(result);
        }

        [Theory(DisplayName = nameof(ShouldReturnTrueIfItIsABusinessDayAndBusinessHours))]
        [Trait("Unit/Specification", "PurchaseDate")]
        [InlineData(2025, 3, 10)]
        [InlineData(2025, 3, 11)]
        [InlineData(2025, 3, 12)]
        [InlineData(2025, 3, 13)]
        [InlineData(2025, 3, 14)]
        public void ShouldReturnTrueIfItIsABusinessDayAndBusinessHours(int year, int month, int day)
        {
            var date = new DateTime(
                year: year,
                month: month,
                day: day,
                hour: 8,
                minute: 0,
                second: 0);

            var order = new OrderEntity(customerId: Guid.NewGuid(), amount: 1, orderDate: date);
            var spec = new PurchaseDateSpecification();

            var result = spec.IsSatisfiedBy(order);

            Assert.True(result);
        }
    }
}
