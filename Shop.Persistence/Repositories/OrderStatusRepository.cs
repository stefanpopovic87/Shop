using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Order;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;

namespace Shop.Persistence.Repositories
{
    public sealed class OrderStatusRepository : IOrderStatusRepository
    {
        private readonly ShopDbContext _context;

        public OrderStatusRepository(ShopDbContext context)
        {
            _context = context;
        }
        public async Task<List<OrderStatus>> GetAllAsync()
        {
            return await _context.OrderStatuses.ToListAsync();
        }

        public async Task<OrderStatus?> GetByIdAsync(int id)
        {
            return await _context.OrderStatuses.FindAsync(id);
        }
    }
}
