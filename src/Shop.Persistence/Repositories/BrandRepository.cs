using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ShopDbContext context)
            : base(context)
        {
        }

        public async Task<bool> IsNameUnique(string name, CancellationToken cancellationToken)
        {
            return await _context.Brands.AnyAsync(x => x.Name == name, cancellationToken);
        }
    }
}