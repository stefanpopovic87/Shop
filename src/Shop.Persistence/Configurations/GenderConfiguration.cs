using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class GenderConfiguration : BaseEntityConfiguration<Gender>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasIndex(g => g.Name).IsUnique();
        }
    }
}
