using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products;

namespace Shop.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Details, pd =>
            {
                pd.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("Name");

                pd.Property(d => d.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("Description");

                pd.Property(d => d.Price)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)")
                    .HasColumnName("Price");

                pd.Property(d => d.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Code");
            });

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
