//using Shop.Domain.Entities.OrderAggregate;
//using Shop.Domain.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace Shop.Application
//{
//    public interface IShopDbContext
//    {
//        public DbSet<Domain.Entities.ProductAggregate.Product> Products { get; set; }
//        public DbSet<Address> Addresses { get; set; }
//        public DbSet<OrderStatus> OrderStatuses { get; set; }
//        public DbSet<Order> Orders { get; set; }
//        public DbSet<OrderItem> OrderItems { get; set; }
//        public DbSet<Domain.Entities.ProductAggregate.Size> Sizes { get; set; }

//        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

//    }
//}
