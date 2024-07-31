using Shop.Application.Interfaces.Base;
using DomainEntities = Shop.Domain.Entities;

namespace Shop.Application.Interfaces
{
    public interface ISizeRepository : IBaseRepository<DomainEntities.Size>
    {
        Task<bool> UniqueNameInCategoryAsync(string name, int categoryId, CancellationToken cancellationToken);
        Task<List<DomainEntities.Size>> GetAllByCategoryIdAsync(int categoryId, CancellationToken cancellationToken);
    }
}
