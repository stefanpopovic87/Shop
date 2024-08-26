using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Persistence.Configurations
{
    public class AuditEntryConfiguration : IEntityTypeConfiguration<AuditEntry>
    {
        public void Configure(EntityTypeBuilder<AuditEntry> builder)
        {
            builder.HasKey(a => a.Id);

            
        }
    }
}
