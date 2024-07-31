using Shop.Application.Interfaces.Base;
using DomainEntities = Shop.Domain.Entities;

namespace Shop.Application.Interfaces
{
    public interface ISubcategoryRepository : IBaseRepository<DomainEntities.Subcategory>
    {
        Task<bool> UniqueNameInCategoryAsync(string name, int categoryId, CancellationToken cancellationToken);
        Task<List<DomainEntities.Subcategory>> GetAllByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}