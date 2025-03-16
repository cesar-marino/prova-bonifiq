using ProvaPub.Application.UseCases.Order.CanPurchase;
using ProvaPub.Domain.Entities;
using ProvaPub.Test.UnitTest.Commons;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Order.CanPurchase
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
