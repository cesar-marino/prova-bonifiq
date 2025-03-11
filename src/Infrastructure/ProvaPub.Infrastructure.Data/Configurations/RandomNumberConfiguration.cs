using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaPub.Domain.Entities;

namespace ProvaPub.Infrastructure.Data.Configurations
{
    public class RandomNumberConfiguration : IEntityTypeConfiguration<RandomNumberEntity>
    {
        public void Configure(EntityTypeBuilder<RandomNumberEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(x => x.Number)
                .ValueGeneratedNever()
                .IsRequired();
        }
    }
}
