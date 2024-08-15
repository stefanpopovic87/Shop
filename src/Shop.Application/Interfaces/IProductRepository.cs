using Shop.Application.Interfaces.Base;
using Shop.Domain.Entities.Products;

namespace Shop.Application.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product?> GetByIdIncludeSizeQuantitiesAsync(int id, CancellationToken cancellationToken);
        Task<List<Product>> GetAllIdIncludeSizeQuantitiesAsync(CancellationToken cancellationToken);
    }
}
