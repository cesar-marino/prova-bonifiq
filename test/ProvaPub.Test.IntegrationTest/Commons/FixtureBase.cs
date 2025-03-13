using Bogus;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Infrastructure.Data.Contexts;

namespace ProvaPub.Test.IntegrationTest.Commons
{
    public abstract class FixtureBase
    {
        public CancellationToken CancellationToken { get; } = default;
        public Faker Faker { get; } = new("pt_BR");

        public ProvaPubContext MakeContext() => new(
            new DbContextOptionsBuilder<ProvaPubContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        public ProductEntity MakeProductEntity(
            Guid? productId = null,
            string? name = null) => new(
                productId: productId ?? Faker.Random.Guid(),
                name: name ?? Faker.Commerce.ProductName());

        public CustomerEntity MakeCustomerEntity(
            Guid? customerId = null,
            string? name = null) => new(
                customerId: customerId ?? Faker.Random.Guid(),
                name: name ?? Faker.Commerce.ProductName());
    }
}
