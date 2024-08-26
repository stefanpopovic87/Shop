using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Products;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class ProductSizeQuantityRepository : BaseRepository<ProductSizeQuantity, ProductDbContext>, IProductSizeQuantityRepository
    {
        public ProductSizeQuantityRepository(ProductDbContext context)
            : base(context)
        {
        }

        public async Task<ProductSizeQuantity?> GetByProductidAndSizeIdAsync(int productid, int sizeId, CancellationToken cancellationToken)
        {
            return await _context.ProductSizeQuantities
                .Where(x => x.ProductId == productid && x.SizeId == sizeId)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> UniqueProductBySizeAsync(int productId, int sizeId, CancellationToken cancellationToken)
        {
            return await _context.ProductSizeQuantities.AnyAsync(x => x.ProductId == productId && x.SizeId == sizeId, cancellationToken);
        }
    }
}
