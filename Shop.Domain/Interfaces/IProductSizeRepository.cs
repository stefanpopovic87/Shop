using Shop.Domain.Entities.Product;

namespace Shop.Domain.Interfaces
{
    public interface IProductSizeRepository
    {
        void Add(ProductSize productSize);
        void Update(ProductSize productSize);
        Task<List<ProductSize>> GetByProductIdAsync(int id);
        Task<ProductSize?> GetByProductIdAndSizeIdAsync(int productId, int sizeId);
        Task<ProductSize?> GetByUniqueIdAsync(int productId, int sizeId);
    }
}
