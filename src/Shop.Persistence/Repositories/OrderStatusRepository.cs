using Shop.Domain.Entities.Order;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class OrderStatusRepository : BaseRepository<OrderStatus>, IOrderStatusRepository
    {

        public OrderStatusRepository(ShopDbContext context)
            : base(context) 
        {
        }        
    }
}
