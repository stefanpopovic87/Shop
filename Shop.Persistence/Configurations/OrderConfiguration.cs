using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Order;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class OrderConfiguration : BaseEntityConfiguration<Order>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.BuyerId)
                   .IsRequired();

            builder.Property(o => o.StatusId)
                   .IsRequired();

            builder.HasOne(o => o.Status)
                   .WithMany()
                   .HasForeignKey(o => o.StatusId);

            builder.HasMany(o => o.Items)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasOne(o => o.ShippingAddress)
                   .WithMany()
                   .HasForeignKey(o => o.ShippingAddressId)
                   .IsRequired(false);
        }
    }
}
