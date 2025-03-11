using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Entities;
using ProvaPub.Infrastructure.Data.Configurations;

namespace ProvaPub.Infrastructure.Data.Contexts
{
    public class ProvaPubContext(DbContextOptions<ProvaPubContext> options) : DbContext(options)
    {
        public DbSet<RandomNumberEntity> RandomNumbers { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RandomNumberConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
