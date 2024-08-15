using Shop.Application.Interfaces.Base;
using Shop.Domain.Entities.Orders;

namespace Shop.Application.Interfaces
{
    public interface IOrderStatusRepository : IBaseRepository<OrderStatus>
    {
    }
}
