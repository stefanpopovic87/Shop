using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Product;

namespace Shop.Persistence.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(ps => new { ps.ProductId, ps.SizeId });

            builder.Property(ps => ps.QuantityInStock)
                   .IsRequired();

            builder.HasOne(ps => ps.Product)
                   .WithMany()
                   .HasForeignKey(ps => ps.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ps => ps.Size)
                   .WithMany()
                   .HasForeignKey(ps => ps.SizeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(ps => ps.ProductId).HasDatabaseName("IX_ProductSize_ProductId");

            builder.HasIndex(ps => new { ps.ProductId, ps.SizeId }).IsUnique();
        }
    }
}
