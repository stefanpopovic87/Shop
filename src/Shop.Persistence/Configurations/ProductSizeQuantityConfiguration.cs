using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Products;

namespace Shop.Persistence.Configurations
{
    public class ProductSizeQuantityConfiguration : IEntityTypeConfiguration<ProductSizeQuantity>
    {
        public void Configure(EntityTypeBuilder<ProductSizeQuantity> builder)
        {
            builder.HasKey(pq => new { pq.ProductId, pq.SizeId });

            builder.HasIndex(pq => new { pq.ProductId, pq.SizeId })
                   .IsUnique();

            builder.Property(pq => pq.QuantityInStock)
                   .IsRequired();

            builder.HasOne(pq => pq.Product)
                   .WithMany(p => p.SizeQuantities)
                   .HasForeignKey(pq => pq.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pq => pq.Size)
                   .WithMany(s => s.SizeQuantities)
                   .HasForeignKey(pq => pq.SizeId)
                   .OnDelete(DeleteBehavior.NoAction);
        }         
    }
}
