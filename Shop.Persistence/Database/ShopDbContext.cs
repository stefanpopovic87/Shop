using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Order;
using Shop.Domain.Entities.Product;
using Shop.Domain.Interfaces;
using Shop.Persistence.Configurations;

namespace Shop.Persistence.Database
{
    public class ShopDbContext : DbContext, IUnitOfWork
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
        }
    }
}
