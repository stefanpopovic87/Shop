using Shop.Domain.Entities;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class CategoryRepository : BaseRepository<Category, ProductDbContext>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext context)
            : base(context)
        {
        }
    }
}
