using Shop.Application.Interfaces.Base;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Interfaces
{
    public interface IProductSizeQuantityRepository : IBaseRepository<ProductEntities.ProductSizeQuantity>
    {
        Task<ProductEntities.ProductSizeQuantity?> GetByProductidAndSizeIdAsync(int productid, int sizeId, CancellationToken cancellationToken);
        Task<bool> UniqueProductBySizeAsync(int productId, int sizeId, CancellationToken cancellationToken);
    }
}
