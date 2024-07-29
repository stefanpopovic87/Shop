using Shop.Domain.Entities;
using Shop.Domain.Interfaces.Base;

namespace Shop.Domain.Interfaces
{
    public interface ISubcategoryRepository : IBaseRepository<Subcategory>
    {
        Task<bool> UniqueNameInCategoryAsync(string name, int categoryId, CancellationToken cancellationToken);
        Task<List<Subcategory>> GetAllByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}