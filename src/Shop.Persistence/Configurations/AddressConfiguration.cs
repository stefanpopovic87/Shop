using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(a => a.BuildingNumber)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(a => a.UnitNumber)
                   .HasMaxLength(10);

            builder.Property(a => a.City)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(a => a.State)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Country)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Zip)
                   .IsRequired()
                   .HasMaxLength(10);
        }        
    }
}
