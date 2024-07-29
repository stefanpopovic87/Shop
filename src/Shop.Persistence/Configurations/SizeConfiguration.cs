using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;
using Shop.Persistence.Configurations.Base;

namespace Shop.Persistence.Configurations
{
    public class SizeConfiguration : BaseEntityConfiguration<Size>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(s => s.Category)
                   .WithMany(c => c.Sizes)
                   .HasForeignKey(s => s.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
