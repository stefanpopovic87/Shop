using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Persistence.Configurations.Base;
using Shop.Domain.Entities;

namespace Shop.Persistence.Configurations
{
    public class SubcategoryConfiguration : BaseEntityConfiguration<Subcategory>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Subcategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.Subcategories)
                   .HasForeignKey(sc => sc.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
