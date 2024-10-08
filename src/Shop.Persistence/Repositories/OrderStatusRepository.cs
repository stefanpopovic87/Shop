using Shop.Domain.Entities.Orders;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class OrderStatusRepository : BaseRepository<OrderStatus, OrderDbContext>, IOrderStatusRepository
    {

        public OrderStatusRepository(OrderDbContext context)
            : base(context) 
        {
        }        
    }
}
