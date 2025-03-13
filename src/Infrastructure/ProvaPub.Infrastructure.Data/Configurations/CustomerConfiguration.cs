using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerModel>
    {
        public void Configure(EntityTypeBuilder<CustomerModel> builder)
        {
            builder.HasKey(x => x.CustomerId);

            builder.Property(x => x.CustomerId)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
