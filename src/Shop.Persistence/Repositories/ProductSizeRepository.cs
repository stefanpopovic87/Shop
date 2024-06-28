using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    public sealed class ProductSizeRepository : BaseRepository<ProductSize>, IProductSizeRepository
    {
        public ProductSizeRepository(ShopDbContext context)
            : base(context) 
        {
        }

        public async Task<ProductSize?> GetByProductIdAndSizeIdAsync(int productId, int sizeId, CancellationToken cancellationToken)
        {
            return await _context.ProductSizes
                .Where(x => x.ProductId == productId && x.SizeId == sizeId)
                .Include(x => x.Product)
                .Include(x => x.Size)
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<ProductSize?> GetByUniqueIdAsync(int productId, int sizeId, CancellationToken cancellationToken)
        {
            return await _context.ProductSizes
               .Where(x => x.ProductId == productId && x.SizeId == sizeId)
               .Include(x => x.Size)
               .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<ProductSize>> GetByProductIdAsync(int productId, CancellationToken cancellationToken)
        {
            return await _context.ProductSizes
                .Where(x => x.ProductId == productId)
                .Include(x => x.Product)
                .Include(x => x.Size)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }        
    }
}
