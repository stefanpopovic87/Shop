using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Product;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasMany(c => c.Sizes)
                   .WithOne(s => s.Category)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(c => c.Name).IsUnique();

        }
    }
}
