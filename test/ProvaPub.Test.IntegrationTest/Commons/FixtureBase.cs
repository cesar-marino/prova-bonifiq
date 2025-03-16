using Bogus;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Infrastructure.Data.Contexts;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Test.IntegrationTest.Commons
{
    public abstract class FixtureBase
    {
        public CancellationToken CancellationToken { get; } = default;
        public Faker Faker { get; } = new("pt_BR");

        public ProvaPubContext MakeContext() => new(
            new DbContextOptionsBuilder<ProvaPubContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        public ProductModel MakeProductModel(
            Guid? productId = null,
            string? name = null) => new(
                productId: productId ?? Faker.Random.Guid(),
                name: name ?? Faker.Commerce.ProductName());

        public CustomerModel MakeCustomerModel(
            Guid? customerId = null,
            string? name = null) => new(
                customerId: customerId ?? Faker.Random.Guid(),
                name: name ?? Faker.Commerce.ProductName());

        public OrderModel MakeOrderModel(
            Guid? orderId = null,
            Guid? customerId = null,
            decimal? amount = null,
            DateTime? orderDate = null) => new(
                orderId: orderId ?? Faker.Random.Guid(),
                amount: amount ?? Faker.Finance.Amount(),
                orderDate: orderDate ?? DateTime.Now,
                customerId: customerId ?? Faker.Random.Guid());
    }
}
