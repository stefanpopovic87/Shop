using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Entities.Orders;
using Shop.Domain.Entities.Products;
using Shop.Application.Interfaces;
using Shop.Persistence.Configurations;

namespace Shop.Persistence.Database
{
    public class ShopDbContext : DbContext, IUnitOfWork
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<ProductSizeQuantity> ProductSizeQuantities { get; set; }

        public DbSet<Address> Addresses { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeQuantityConfiguration());

            // TODO Add global filter for all entities that inherit from BaseEntity
            //foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            //    .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            //{
            //    var method = typeof(ShopDbContext).GetMethod(nameof(SetGlobalQueryFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
            //        ?.MakeGenericMethod(entityType.ClrType);
            //    method?.Invoke(null, new object[] { modelBuilder });
            //}
        }

        //private static void SetGlobalQueryFilter<T>(ModelBuilder modelBuilder) where T : BaseEntity
        //{
        //    modelBuilder.Entity<T>().HasQueryFilter(e => !e.Deleted);
        //}
    }
}
