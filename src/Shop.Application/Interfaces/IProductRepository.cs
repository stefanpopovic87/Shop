using Shop.Application.Interfaces.Base;
using ProductEntities = Shop.Domain.Entities.Product;

namespace Shop.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductEntities.Product>
    {
        Task<ProductEntities.Product?> GetByIdIncludeSizeQuantitiesAsync(int id, CancellationToken cancellationToken);
        Task<List<ProductEntities.Product>> GetAllIdIncludeSizeQuantitiesAsync(CancellationToken cancellationToken);
    }
}
