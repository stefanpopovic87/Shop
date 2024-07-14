using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces.Base;

namespace Shop.Domain.Interfaces
{
    public interface ISizeRepository : IBaseRepository<Size>
    {
        Task<bool> UniqueNameInCategoryAsync(string name, int categoryId, CancellationToken cancellationToken);
        Task<List<Size>> GetAllByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}
