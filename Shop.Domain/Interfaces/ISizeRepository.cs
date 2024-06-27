using Shop.Domain.Entities.Product;

namespace Shop.Domain.Interfaces
{
    public interface ISizeRepository
    {
        Task<Size?> GetByIdAsync(int id);
    }
}
