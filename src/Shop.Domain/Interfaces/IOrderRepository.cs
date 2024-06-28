using Shop.Domain.Entities.Order;
using Shop.Domain.Interfaces.Base;

namespace Shop.Domain.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order?> GetAsync(CancellationToken cancellationToken);
    }
}
