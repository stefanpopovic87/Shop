using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Orders;
using Shop.Domain.Entities.Products;
using Shop.Application.Interfaces;
using Shop.Persistence.Configurations;

namespace Shop.Persistence.Database
{
    public class ProductDbContext : DbContext, IProductUnitOfWork
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<OrderStatus> OrderStatuses { get; set; }
        //public DbSet<Address> Addresses { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ProductSizeQuantity> ProductSizeQuantities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeQuantityConfiguration());
        }       
    }
}
