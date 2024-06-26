using Shop.Domain.Entities.Product;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Update(Product product);
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsync();       
    }
}
