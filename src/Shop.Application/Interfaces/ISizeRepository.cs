using Shop.Application.Interfaces.Base;
using Shop.Domain.Entities;

namespace Shop.Application.Interfaces
{
    public interface ISizeRepository : IBaseRepository<Size>
    {
        Task<bool> UniqueNameInCategoryAsync(string name, int categoryId, CancellationToken cancellationToken);
        Task<List<Size>> GetAllByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}
