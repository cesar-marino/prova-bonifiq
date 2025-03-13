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
            name: Faker.Random.String());

        public CustomerEntity MakeCustomerEntity() => new(
            customerId: Faker.Random.Guid(),
            name: Faker.Random.String());
    }
}
