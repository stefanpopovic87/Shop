using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Enums;
using Shop.Domain.Entities.Order;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class OrderStatusConfiguration : BaseEntityConfiguration<OrderStatus>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);

            builder.Property(os => os.Name)
               .IsRequired()
               .HasMaxLength(100);

            //IEnumerable<OrderStatus> statuses = Enum.GetValues<OrderStatusEnum>()
            //    .Select(s => new OrderStatus((int)s, s.ToString()));

            //builder.HasData(statuses);
        }
    }
}
