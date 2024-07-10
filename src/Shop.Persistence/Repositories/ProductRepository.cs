using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ShopDbContext context)
            : base(context)
        {
        }

        public async override Task<List<Product>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Products
                .Where(p => !p.Deleted)
                .AsNoTracking()
                .ToListAsync(cancellationToken);                
        }
    }
}
