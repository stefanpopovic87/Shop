using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(ShopDbContext context)
            : base(context)
        {
        }
    }
}
