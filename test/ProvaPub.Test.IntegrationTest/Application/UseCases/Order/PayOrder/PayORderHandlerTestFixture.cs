using ProvaPub.Application.UseCases.Order.PayOrder;
using ProvaPub.Test.IntegrationTest.Commons;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Order.PayOrder
{
    public class PayORderHandlerTestFixture : FixtureBase
    {
        public PayOrderRequest MakePayOrderRequest(
            Guid? customerId = null,
            string? paymentMathod = null,
            decimal? amount = null) => new(
                customerId: customerId ?? Faker.Random.Guid(),
                paymentMethod: paymentMathod ?? Faker.Random.String(),
                amount: amount ?? Faker.Random.Decimal());
    }
}
