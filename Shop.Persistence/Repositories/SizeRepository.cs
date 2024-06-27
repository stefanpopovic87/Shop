using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;

namespace Shop.Persistence.Repositories
{
    public sealed class SizeRepository : ISizeRepository
    {
        private readonly ShopDbContext _context;

        public SizeRepository(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<Size?> GetByIdAsync(int id)
        {
            return await _context.Sizes.FindAsync(id);
        }
    }
}
