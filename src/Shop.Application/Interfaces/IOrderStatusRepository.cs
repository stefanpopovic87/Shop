using Shop.Application.Interfaces.Base;
using Shop.Domain.Entities.Order;

namespace Shop.Application.Interfaces
{
    public interface IOrderStatusRepository : IBaseRepository<OrderStatus>
    {
    }
}
