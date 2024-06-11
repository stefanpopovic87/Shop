using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.OrderAggregate;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Database
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
