using Shop.Application.Interfaces.Base;
using Shop.Domain.Entities.Products;

namespace Shop.Application.Interfaces
{
    public interface IProductSizeQuantityRepository : IBaseRepository<ProductSizeQuantity>
    {
        Task<ProductSizeQuantity?> GetByProductidAndSizeIdAsync(int productid, int sizeId, CancellationToken cancellationToken);
        Task<bool> UniqueProductBySizeAsync(int productId, int sizeId, CancellationToken cancellationToken);
    }
}
