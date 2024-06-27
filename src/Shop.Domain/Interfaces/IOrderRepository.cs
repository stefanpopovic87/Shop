using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Product;

namespace Shop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetAsync();
        void Add(Order order);

    }
}
