using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Enums;
using Shop.Domain.Entities.Product;

namespace Shop.Persistence.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(p => p.Id);

            IEnumerable<Size> sizes = Enum.GetValues<SizeEnum>()
                .Select(s => new Size ((int)s, s.ToString()));

            builder.HasData(sizes);
        }
    }
}
