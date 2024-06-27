using Shop.Domain.Entities.Order;

namespace Shop.Domain.Interfaces
{
    public interface IOrderStatusRepository
    {
        Task<OrderStatus?> GetByIdAsync(int id);
        Task<List<OrderStatus>> GetAllAsync();
    }
}
