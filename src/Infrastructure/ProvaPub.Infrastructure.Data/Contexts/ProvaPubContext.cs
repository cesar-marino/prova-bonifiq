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
            List<ProductEntity> result = [];

            for (int i = 0; i < 20; i++)
            {
                var guid = Guid.NewGuid().ToString();
                result.Add(new ProductEntity(productId: Guid.Parse(guid), name: $"Product {i}"));
            }

            return [.. result];
        }
    }
}