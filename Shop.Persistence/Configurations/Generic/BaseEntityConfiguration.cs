using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities.Base;

namespace Shop.Persistence.Configurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(p => p.DateCreated).IsRequired();
            builder.Property(p => p.DateModified);
            builder.Property(p => p.DateDeleted);
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.ModifiedBy);
            builder.Property(p => p.DeletedBy);
            builder.Property(p => p.Inactive).IsRequired().HasDefaultValue(false);

            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
    }
}
