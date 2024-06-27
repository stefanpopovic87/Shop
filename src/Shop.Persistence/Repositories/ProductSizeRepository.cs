using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;

namespace Shop.Persistence.Repositories
{
    public sealed class ProductSizeRepository : IProductSizeRepository
    {
        private readonly ShopDbContext _context;

        public ProductSizeRepository(ShopDbContext context)
        {
            _context = context;
        }

        public void Add(ProductSize priductSize)
        {
            _context.ProductSizes.Add(priductSize);
        }

        public void Update(ProductSize priductSize)
        {
            _context.ProductSizes.Update(priductSize);
        }

        public async Task<ProductSize?> GetByProductIdAndSizeIdAsync(int productId, int sizeId)
        {
            return await _context.ProductSizes
                .Where(x => x.ProductId == productId && x.SizeId == sizeId)
                .Include(x => x.Product)
                .Include(x => x.Size)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<ProductSize?> GetByUniqueIdAsync(int productId, int sizeId)
        {
            return await _context.ProductSizes
               .Where(x => x.ProductId == productId && x.SizeId == sizeId)
               .Include(x => x.Size)
               .FirstOrDefaultAsync();
        }

        public async Task<List<ProductSize>> GetByProductIdAsync(int productId)
        {
            return await _context.ProductSizes
                .Where(x => x.ProductId == productId)
                .Include(x => x.Product)
                .Include(x => x.Size)
                .AsNoTracking()
                .ToListAsync();
        }        
    }
}
