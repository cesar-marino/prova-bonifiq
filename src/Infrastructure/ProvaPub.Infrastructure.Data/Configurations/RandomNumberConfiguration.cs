using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaPub.Infrastructure.Data.Models;

namespace ProvaPub.Infrastructure.Data.Configurations
{
    public class RandomNumberConfiguration : IEntityTypeConfiguration<RandomNumberModel>
    {
        public void Configure(EntityTypeBuilder<RandomNumberModel> builder)
        {
            builder.HasKey(x => x.RandomNumberId);

            builder.Property(x => x.RandomNumberId)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Number)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}
