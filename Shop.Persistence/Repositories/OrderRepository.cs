using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;

namespace Shop.Persistence.Repositories
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly ShopDbContext _context;

        public OrderRepository(ShopDbContext context)
        {
            _context = context;
        }

        public async Task<Order?> GetAsync()
        {
            return await _context.Orders
                 .Where(o => o.BuyerId == 1)  // TODO - chage to current user ID
                 .Include(o => o.Items)
                 .ThenInclude(oip => oip.Product)
                 .Include(o => o.Items)
                 .ThenInclude(ois => ois.Size)
                 .FirstOrDefaultAsync();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
