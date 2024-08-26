using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Base;

namespace Shop.Persistence.Repositories.Base
{
    public abstract class BaseRepository<T, TContext> : IBaseRepository<T>
        where T : class
        where TContext : DbContext
    {
        protected readonly TContext _context;

        protected BaseRepository(TContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FindAsync([id], cancellationToken);
        }

        public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
        }

         public virtual async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AnyAsync(e => EF.Property<int>(e, "Id") == id, cancellationToken);
        }

        public async Task<bool> UniqueNameAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().AnyAsync(e => EF.Property<string>(e, "Name").ToLower() == name.ToLower(), cancellationToken);
        }
    }
}
