using Shop.Domain.Entities.Product;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();
        void Add(Product product);
    }
}
