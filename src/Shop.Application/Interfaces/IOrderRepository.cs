using Shop.Application.Interfaces.Base;
using OrderEntities = Shop.Domain.Entities.Order;

namespace Shop.Application.Interfaces
{
    public interface IOrderRepository : IBaseRepository<OrderEntities.Order>
    {
        Task<OrderEntities.Order?> GetAsync(CancellationToken cancellationToken);
    }
}
