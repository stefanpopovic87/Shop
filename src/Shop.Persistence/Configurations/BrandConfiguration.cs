using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class BrandConfiguration : BaseEntityConfiguration<Brand>
    {       
        protected override void ConfigureEntity(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(b => b.Products)
                   .WithOne(p => p.Brand)
                   .HasForeignKey(p => p.BrandId);

            builder.HasIndex(p => p.Name).IsUnique();


            //IEnumerable<Brand> brands = Enum.GetValues<BrandEnum>()
            //    .Select(s => new Brand((int)s, s.ToString()));

            //builder.HasData(brands);
        }
    }
}
