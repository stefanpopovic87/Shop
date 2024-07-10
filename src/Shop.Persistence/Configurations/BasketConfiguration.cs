using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.BuyerId)
                   .IsRequired();

            builder.Property(b => b.PaymentIntentId)
                   .HasMaxLength(250);

            builder.Property(b => b.ClientSecret)
                   .HasMaxLength(250);

            builder.HasMany(b => b.Items)
                   .WithOne(bi => bi.Basket)
                   .HasForeignKey(bi => bi.BasketId);

            // BaseEntity properties configuration
            builder.Property(p => p.DateCreated).IsRequired();
            builder.Property(p => p.DateModified);
            builder.Property(p => p.DateDeleted);
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.ModifiedBy);
            builder.Property(p => p.DeletedBy);
            builder.Property(oi => oi.Deleted).IsRequired().HasDefaultValue(false);
        }
    }
}
