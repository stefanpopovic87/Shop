using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Orders;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class OrderItemConfiguration : BaseEntityConfiguration<OrderItem>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.Property(oi => oi.ProductId)
                   .IsRequired();

            builder.Property(oi => oi.SizeId)
                   .IsRequired();

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(e => e.Product)
                 .WithMany()
                 .HasForeignKey(e => e.ProductId);

            builder.HasOne(e => e.Size)
                  .WithMany()
                  .HasForeignKey(e => e.SizeId);

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.Items)
                   .HasForeignKey(oi => oi.OrderId);
        }
    }
}
