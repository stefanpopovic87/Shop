using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Shop.Domain.Entities;
using Shop.Persistence.Database;

namespace Shop.Persistence.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        private readonly List<AuditEntry> _auditEntries;
        private readonly HistoryDbContext _historyContext;

        public AuditInterceptor(List<AuditEntry> auditEntries, HistoryDbContext historyContext)
        {
            _auditEntries = auditEntries;
            _historyContext = historyContext;
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
            {
                return ValueTask.FromResult(result);
            }

            var databaseName = GetDatabaseName(eventData.Context);


            foreach (var entry in eventData.Context.ChangeTracker.Entries())
            {
                if (entry.Entity is AuditEntry || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry
                {
                    UserId = 1, //TODO - change to current user
                    Type = entry.State.ToString(),
                    TableName = entry?.Metadata?.GetTableName(),
                    DateTime = DateTime.UtcNow,
                    Entity = entry?.Entity,
                    DatabaseName = databaseName

                };

                switch (entry.State)
                {
                    case EntityState.Deleted:
                        auditEntry.OldValues = JsonConvert.SerializeObject(entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.OriginalValue));
                        auditEntry.PrimaryKey = (int)entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.OriginalValue!;
                        break;
                    case EntityState.Modified:
                        auditEntry.OldValues = JsonConvert.SerializeObject(entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.OriginalValue));
                        auditEntry.AffectedColumns = string.Join(",", entry.Properties.Where(p => p.IsModified).Select(p => p.Metadata.Name));
                        auditEntry.PrimaryKey = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.OriginalValue as int? ?? 0; 
                        break;
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Added:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _auditEntries.Add(auditEntry);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null || _auditEntries.Count == 0)
            {
                return await base.SavedChangesAsync(eventData, result, cancellationToken);
            }

            var entities = eventData.Context.ChangeTracker.Entries();

            foreach (var entry in entities)
            {               

                var auditEntry = _auditEntries.FirstOrDefault(ae => ae.Entity == entry.Entity);
                if (auditEntry != null)
                {
                    if (auditEntry.Type == EntityState.Added.ToString())
                    {
                        auditEntry.NewValues = JsonConvert.SerializeObject(entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.CurrentValue));
                        auditEntry.PrimaryKey = (int)entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue!;
                    }

                    else if (auditEntry.Type == EntityState.Modified.ToString())
                    {
                        auditEntry.NewValues = JsonConvert.SerializeObject(entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.CurrentValue));
                    }
                }
            }

            if (_auditEntries.Count > 0)
            {
                _historyContext.AuditEntries.AddRange(_auditEntries);
                await _historyContext.SaveChangesAsync(cancellationToken);
                _auditEntries.Clear();
            }

            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        private string GetDatabaseName(DbContext context)
        {
            return context.GetType().Name switch
            {
                nameof(ProductDbContext) => "ProductDb",
                nameof(OrderDbContext) => "OrderDb",
                nameof(HistoryDbContext) => "HistoryDb",
                _ => "UnknownDb"
            };
        }
    }
}
