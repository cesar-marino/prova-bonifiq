using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
