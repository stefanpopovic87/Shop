using Shop.Domain.Entities;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class GenderRepository : BaseRepository<Gender, ProductDbContext>, IGenderRepository
    {
        public GenderRepository(ProductDbContext context)
            : base(context)
        {
        }
    }
}
