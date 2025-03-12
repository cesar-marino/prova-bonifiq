using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Infrastructure.Data.Configurations;

namespace ProvaPub.Infrastructure.Data.Contexts
{
    public class ProvaPubContext(DbContextOptions<ProvaPubContext> options) : DbContext(options)
    {
        public DbSet<RandomNumberEntity> RandomNumbers { get; private set; }
        public DbSet<ProductEntity> Products { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RandomNumberConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.Entity<ProductEntity>().HasData(GetProductSeed());
            //modelBuilder.Entity<Customer>().HasData(getCustomerSeed());
            modelBuilder.Entity<RandomNumberEntity>().HasIndex(s => s.Number).IsUnique();

            base.OnModelCreating(modelBuilder);
        }

        private static List<ProductEntity> GetProductSeed()
        {
            List<ProductEntity> products = [];

            for (int i = 0; i < 20; i++)
                products.Add(new(name: $"Product {i}"));

            return products;

            //return
            //[
            //    new(productId: Guid.Parse("b9cbf743-f5e8-47a5-b23d-51b311b0bf87"), name: "Product 1"),
            //    new(productId: Guid.Parse("215cf962-f89d-4f88-ad4a-62b5313707d8"), name: "Product 2"),
            //    new(productId: Guid.Parse("80ef4535-eeb4-41e0-9323-6ace9757b828"), name: "Product 3"),
            //    new(productId: Guid.Parse("0d7e9aa8-50d7-4966-adb0-3553175a7d24"), name: "Product 4"),
            //    new(productId: Guid.Parse("bb80b4d3-cfaf-4974-ba23-cfa636659171"), name: "Product 5"),
            //    new(productId: Guid.Parse("bea89c8e-1904-4b3b-96c5-726e75dc84a1"), name: "Product 6"),
            //    new(productId: Guid.Parse("6ef8ffb6-72dc-4a1f-85d0-e7b9238865ac"), name: "Product 7"),
            //    new(productId: Guid.Parse("8053622f-2ac1-47de-af76-a1817500f54b"), name: "Product 8"),
            //    new(productId: Guid.Parse("eeec841c-e3b5-48dc-9607-d8ec85a76639"), name: "Product 9"),
            //    new(productId: Guid.Parse("c1bfbc67-3988-4c21-899a-74fb4f6bd96d"), name: "Product 10"),
            //    new(productId: Guid.Parse("22474301-3380-4936-87f2-b5a1b1e3413b"), name: "Product 11"),
            //    new(productId: Guid.Parse("3b480b89-17d9-412c-a057-d47792aa742a"), name: "Product 12"),
            //    new(productId: Guid.Parse("b8b52983-9643-41d9-99d0-b5a739187274"), name: "Product 13"),
            //    new(productId: Guid.Parse("080711bd-8395-4004-b79f-5fcbc9f9c06a"), name: "Product 14"),
            //    new(productId: Guid.Parse("109d9239-a22b-4aa0-82d6-f6227c54c9a4"), name: "Product 15"),
            //    new(productId: Guid.Parse("ea03c9e0-4ac2-4b72-a0fb-7a554fab784d"), name: "Product 16"),
            //    new(productId: Guid.Parse("f03aad02-3b57-4e39-9fb6-ff31a17beb0e"), name: "Product 17"),
            //    new(productId: Guid.Parse("5f86effc-a076-446d-abfc-b4bb9852fc34"), name: "Product 18"),
            //    new(productId: Guid.Parse("6a385b22-5af2-4184-98e6-64bc45aef7a3"), name: "Product 19"),
            //    new(productId: Guid.Parse("60297082-67d5-48d3-b6dd-5ccf4d1b7bc8"), name: "Product 20")
            //];
        }
    }
}