using Shop.Application.Interfaces.Base;
using Shop.Domain.Entities;

namespace Shop.Application.Interfaces
{
    public interface ISubcategoryRepository : IBaseRepository<Subcategory>
    {
        Task<bool> UniqueNameInCategoryAsync(string name, int categoryId, CancellationToken cancellationToken);
        Task<List<Subcategory>> GetAllByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}