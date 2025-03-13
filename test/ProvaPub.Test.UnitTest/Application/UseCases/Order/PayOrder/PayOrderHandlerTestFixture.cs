using ProvaPub.Application.UseCases.Order.PayOrder;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Order.PayOrder
{
    public class PayOrderHandlerTestFixture : FixtureBase
    {
        public PayOrderRequest MakePayOrderRequest() => new(
            customerId: Faker.Random.Guid(),
            paymentMethod: Faker.Random.String(),
            amount: Faker.Random.Decimal());
    }
}
