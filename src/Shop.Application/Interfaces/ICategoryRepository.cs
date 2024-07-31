using Shop.Application.Interfaces.Base;
using DomainEntities = Shop.Domain.Entities;

namespace Shop.Application.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<DomainEntities.Category>
    {
    }
}
