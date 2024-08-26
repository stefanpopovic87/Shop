using Shop.Domain.Entities.Orders;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class OrderStatusRepository : BaseRepository<OrderStatus, ProductDbContext>, IOrderStatusRepository
    {

        public OrderStatusRepository(ProductDbContext context)
            : base(context) 
        {
        }        
    }
}
