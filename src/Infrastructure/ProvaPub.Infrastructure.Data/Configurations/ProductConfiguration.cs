using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(x => x.ProductId);

            builder.Property(x => x.ProductId)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Name)
                .IsRequired();
        }
    }
}
