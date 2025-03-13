using Microsoft.EntityFrameworkCore;
using ProvaPub.Infrastructure.Data.Configurations;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Infrastructure.Data.Contexts
{
    public class ProvaPubContext(DbContextOptions<ProvaPubContext> options) : DbContext(options)
    {
        public DbSet<RandomNumberModel> RandomNumbers { get; private set; }
        public DbSet<ProductModel> Products { get; private set; }
        public DbSet<CustomerModel> Customers { get; private set; }
        public DbSet<OrderModel> Orders { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RandomNumberConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Entity<ProductModel>().HasData(GetProductSeed());
            modelBuilder.Entity<CustomerModel>().HasData(GetCustomerSeed());
            modelBuilder.Entity<RandomNumberModel>().HasIndex(s => s.Number).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        private static List<CustomerModel> GetCustomerSeed()
        {
            //List<CustomerEntity> customers = [];

            //for (int i = 0; i < 20; i++)
            //    customers.Add(new(name: $"Customer {i}"));

            //return customers;

            return
            [
                new(customerId: Guid.Parse("747cb2c4-284a-4b0b-b112-5240948c8f35"), name: "Customer 1"),
                new(customerId: Guid.Parse("d056c7ca-2cbe-42f0-84ee-f0b9e314ba03"), name: "Customer 2"),
                new(customerId: Guid.Parse("6aa0b12c-a645-4a91-8468-e865dfa3fd3e"), name: "Customer 3"),
                new(customerId: Guid.Parse("d12a7211-4580-4e25-b8b2-be08232c9afc"), name: "Customer 4"),
                new(customerId: Guid.Parse("6ec8a7f9-2987-432f-b2a3-b56ff491a11d"), name: "Customer 5"),
                new(customerId: Guid.Parse("dc0c6034-8351-41ca-bdf8-37931f78993d"), name: "Customer 6"),
                new(customerId: Guid.Parse("dc533d52-a956-411a-9ac8-490963d8793f"), name: "Customer 7"),
                new(customerId: Guid.Parse("6c52d19b-6070-401e-9a42-a0f188972e36"), name: "Customer 8"),
                new(customerId: Guid.Parse("0db09350-9a3c-40c1-bcfa-603acec7b65d"), name: "Customer 9"),
                new(customerId: Guid.Parse("70afbd9a-bb53-4950-9225-be467c81f081"), name: "Customer 10"),
                new(customerId: Guid.Parse("15e0454b-8378-4423-9374-947d7c1a0cb1"), name: "Customer 11"),
                new(customerId: Guid.Parse("5bd20719-ebc8-44ac-8890-adacfdd00c0b"), name: "Customer 12"),
                new(customerId: Guid.Parse("f1c3f2f8-1100-47f2-863a-dd9922e87f81"), name: "Customer 13"),
                new(customerId: Guid.Parse("d65859b1-61c1-4096-8a48-b4aa1c95bccc"), name: "Customer 14"),
                new(customerId: Guid.Parse("f5b5bf67-8156-482f-8877-1f248572a55d"), name: "Customer 15"),
                new(customerId: Guid.Parse("e304e618-855e-434f-a65d-9939f0788988"), name: "Customer 16"),
                new(customerId: Guid.Parse("588d58ad-7648-4cc5-897b-3be539d2a068"), name: "Customer 17"),
                new(customerId: Guid.Parse("43749f94-bb6a-4219-b491-d9076b8f44d9"), name: "Customer 18"),
                new(customerId: Guid.Parse("65415a69-67dd-42fa-b46e-000a5761c09e"), name: "Customer 19"),
                new(customerId: Guid.Parse("1040c9f9-7f56-4c5d-90ac-d3b69bee8a15"), name: "Customer 20")
            ];
        }

        private static List<ProductModel> GetProductSeed()
        {
            //List<ProductEntity> products = [];

            //for (int i = 0; i < 20; i++)
            //    products.Add(new(name: $"Product {i}"));

            //return products;

            return
            [
                new(productId: Guid.Parse("b9cbf743-f5e8-47a5-b23d-51b311b0bf87"), name: "Product 1"),
                new(productId: Guid.Parse("215cf962-f89d-4f88-ad4a-62b5313707d8"), name: "Product 2"),
                new(productId: Guid.Parse("80ef4535-eeb4-41e0-9323-6ace9757b828"), name: "Product 3"),
                new(productId: Guid.Parse("0d7e9aa8-50d7-4966-adb0-3553175a7d24"), name: "Product 4"),
                new(productId: Guid.Parse("bb80b4d3-cfaf-4974-ba23-cfa636659171"), name: "Product 5"),
                new(productId: Guid.Parse("bea89c8e-1904-4b3b-96c5-726e75dc84a1"), name: "Product 6"),
                new(productId: Guid.Parse("6ef8ffb6-72dc-4a1f-85d0-e7b9238865ac"), name: "Product 7"),
                new(productId: Guid.Parse("8053622f-2ac1-47de-af76-a1817500f54b"), name: "Product 8"),
                new(productId: Guid.Parse("eeec841c-e3b5-48dc-9607-d8ec85a76639"), name: "Product 9"),
                new(productId: Guid.Parse("c1bfbc67-3988-4c21-899a-74fb4f6bd96d"), name: "Product 10"),
                new(productId: Guid.Parse("22474301-3380-4936-87f2-b5a1b1e3413b"), name: "Product 11"),
                new(productId: Guid.Parse("3b480b89-17d9-412c-a057-d47792aa742a"), name: "Product 12"),
                new(productId: Guid.Parse("b8b52983-9643-41d9-99d0-b5a739187274"), name: "Product 13"),
                new(productId: Guid.Parse("080711bd-8395-4004-b79f-5fcbc9f9c06a"), name: "Product 14"),
                new(productId: Guid.Parse("109d9239-a22b-4aa0-82d6-f6227c54c9a4"), name: "Product 15"),
                new(productId: Guid.Parse("ea03c9e0-4ac2-4b72-a0fb-7a554fab784d"), name: "Product 16"),
                new(productId: Guid.Parse("f03aad02-3b57-4e39-9fb6-ff31a17beb0e"), name: "Product 17"),
                new(productId: Guid.Parse("5f86effc-a076-446d-abfc-b4bb9852fc34"), name: "Product 18"),
                new(productId: Guid.Parse("6a385b22-5af2-4184-98e6-64bc45aef7a3"), name: "Product 19"),
                new(productId: Guid.Parse("60297082-67d5-48d3-b6dd-5ccf4d1b7bc8"), name: "Product 20")
            ];
        }
    }
}