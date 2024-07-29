using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces.Base;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> GetByIdIncludeSizeQuantitiesAsync(int id, CancellationToken cancellationToken);
        Task<List<Product>> GetAllIdIncludeSizeQuantitiesAsync(CancellationToken cancellationToken);
    }
}
