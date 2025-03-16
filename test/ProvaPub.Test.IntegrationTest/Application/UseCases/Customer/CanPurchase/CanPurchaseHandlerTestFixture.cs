using ProvaPub.Application.UseCases.Customer.CanPurchase;
using ProvaPub.Test.IntegrationTest.Commons;

namespace ProvaPub.Test.IntegrationTest.Application.UseCases.Customer.CanPurchase
{
    public class CanPurchaseHandlerTestFixture : FixtureBase
    {
        public CanPurchaseRequest MakeCanPurchaseRequest(
            Guid? customerId = null,
            decimal? amount = null) => new(
                customerId: customerId ?? Faker.Random.Guid(),
                amount: amount ?? Faker.Finance.Amount());
    }
}
