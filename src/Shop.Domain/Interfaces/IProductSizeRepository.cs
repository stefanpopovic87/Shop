using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces.Base;

namespace Shop.Domain.Interfaces
{
    public interface IProductSizeRepository : IBaseRepository<ProductSize>
    {
        Task<List<ProductSize>> GetByProductIdAsync(int id, CancellationToken cancellationToken);
        Task<ProductSize?> GetByProductIdAndSizeIdAsync(int productId, int sizeId, CancellationToken cancellationToken);
        Task<ProductSize?> GetByUniqueIdAsync(int productId, int sizeId, CancellationToken cancellationToken);
    }
}
