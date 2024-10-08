using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.UnitOfWork;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Orders;
using Shop.Persistence.Configurations;

namespace Shop.Persistence.Database
{
    public class OrderDbContext : DbContext, IOrderUnitOfWork
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
        }

    }
}
