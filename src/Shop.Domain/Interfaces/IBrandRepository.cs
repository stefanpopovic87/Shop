using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces.Base;

namespace Shop.Domain.Interfaces
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        Task<bool> IsNameUnique(string name, CancellationToken cancellationToken);
    }
}
