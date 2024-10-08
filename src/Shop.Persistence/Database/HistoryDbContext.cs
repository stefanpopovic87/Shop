using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.UnitOfWork;
using Shop.Domain.Entities;
using Shop.Persistence.Configurations;

namespace Shop.Persistence.Database
{
    public class HistoryDbContext : DbContext, IHistoryUnitOfWork
    {
        public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options) { }

        public DbSet<AuditEntry> AuditEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuditEntryConfiguration());
        }

    }
}
