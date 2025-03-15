using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;

namespace ProvaPub.Test.UnitTest.Domain.Entities
{
    public class OrderEntityTest
    {
        [Theory(DisplayName = nameof(ShouldThrowEntityValidationExceptionIfTheAmountIsLessThanOrEqualToZero))]
        [Trait("Unit/Entities", "Order")]
        [InlineData(0)]
        [InlineData(-10)]
        [InlineData(-52.12)]
        public void ShouldThrowEntityValidationExceptionIfTheAmountIsLessThanOrEqualToZero(decimal amount)
        {
            var act = () => new OrderEntity(customerId: Guid.NewGuid(), amount: amount);

            var exception = Assert.Throws<EntityValidationException>(act);
            Assert.Equal("entity-validation", exception.Code);
            Assert.Equal("O valor da compra deve ser maior que zero", exception.Message);
        }
    }
}
