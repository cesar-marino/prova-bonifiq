using ProvaPub.Application.UseCases.Customer.CanPurchase;
using ProvaPub.Domain.Entities;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Customer.CanPurchase
{
    public class CanPurchaseHandlerTestFixture : FixtureBase
    {
        public CanPurchaseRequest MakeCanPurchaseRequest() => new(
            customerId: Faker.Random.Guid(),
            amount: Faker.Finance.Amount());

        public IReadOnlyList<OrderEntity> MakeListOrders() =>
        [
            MakeOrderEntity(),
            MakeOrderEntity(),
            MakeOrderEntity(),
        ];
    }
}
