using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Order;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class OrderRepository : BaseRepository<Order>, IOrderRepository
    {

        public OrderRepository(ShopDbContext context)
            : base(context)
        {
        }

        public async Task<Order?> GetAsync(CancellationToken cancellationToken)
        {
            return await _context.Orders
                 .Where(o => o.BuyerId == 1)  // TODO - change to current user ID
                 .Include(o => o.Items)
                 .ThenInclude(oip => oip.Product)
                 .Include(o => o.Items)
                 .ThenInclude(ois => ois.Size)
                 .FirstOrDefaultAsync(cancellationToken);
        }        
    }
}
