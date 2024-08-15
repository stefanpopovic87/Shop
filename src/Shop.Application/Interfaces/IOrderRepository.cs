using Shop.Application.Interfaces.Base;
using Shop.Domain.Entities.Orders;

namespace Shop.Application.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order?> GetAsync(CancellationToken cancellationToken);
    }
}
