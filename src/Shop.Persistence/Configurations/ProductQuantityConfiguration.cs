using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Product;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class ProductQuantityConfiguration : BaseEntityConfiguration<ProductQuantity>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<ProductQuantity> builder)
        {
            builder.HasKey(pq => new { pq.ProductId, pq.SizeId });

            builder.HasIndex(pq => new { pq.ProductId, pq.SizeId })
                   .IsUnique();

            builder.Property(pq => pq.QuantityInStock)
                   .IsRequired();

            builder.HasOne(pq => pq.Product)
                   .WithMany(p => p.ProductQuantities)
                   .HasForeignKey(pq => pq.ProductId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(pq => pq.Size)
                   .WithMany(s => s.ProductQuantities)
                   .HasForeignKey(pq => pq.SizeId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
