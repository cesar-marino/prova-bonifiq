using Bogus;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Test.UnitTest.Commons
{
    public abstract class FixtureBase
    {
        public CancellationToken CancellationToken { get; } = default;
        public Faker Faker { get; } = new("pt_BR");

        public ProductEntity MakeProductEntity() => new(
            productId: Faker.Random.Guid(),
            name: Faker.Commerce.Product());

        public CustomerEntity MakeCustomerEntity() => new(
            customerId: Faker.Random.Guid(),
            name: Faker.Person.FullName);

        public OrderEntity MakeOrderEntity() => new(
            customerId: Faker.Random.Guid(),
            amount: Faker.Finance.Amount(),
            orderDate: Faker.Date.Past());
    }
}
