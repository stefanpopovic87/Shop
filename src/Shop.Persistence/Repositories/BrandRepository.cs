using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ShopDbContext context)
            : base(context)
        {
        }
    }
}