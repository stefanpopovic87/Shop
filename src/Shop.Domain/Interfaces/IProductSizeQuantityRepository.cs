using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces.Base;

namespace Shop.Domain.Interfaces
{
    public interface IProductSizeQuantityRepository : IBaseRepository<ProductSizeQuantity>
    {
        Task<ProductSizeQuantity?> GetByProductidAndSizeIdAsync(int productid, int sizeId, CancellationToken cancellationToken);
        Task<bool> UniqueProductBySizeAsync(int productId, int sizeId, CancellationToken cancellationToken);
    }
}
