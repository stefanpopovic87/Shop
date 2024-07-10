using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Product;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Code)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.HasOne(p => p.Brand)
                   .WithMany(b => b.Products)
                   .HasForeignKey(p => p.BrandId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Subcategory)
                   .WithMany(sc => sc.Products)
                   .HasForeignKey(p => p.SubcategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Gender)
                   .WithMany(g => g.Products)
                   .HasForeignKey(p => p.GenderId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
