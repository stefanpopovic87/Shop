using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Enums;
using Shop.Domain.Entities.Order;

namespace Shop.Persistence.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);

            builder.Property(os => os.Name)
               .IsRequired()
               .HasMaxLength(100);

            IEnumerable<OrderStatus> statuses = Enum.GetValues<OrderStatusEnum>()
                .Select(s => new OrderStatus((int)s, s.ToString()));

            builder.HasData(statuses);
        }
    }
}
