using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<ShopDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("ShopConnection");
                options.UseSqlServer(connectionString, sqlOptions => sqlOptions.MigrationsAssembly(typeof(ShopDbContext).Assembly.FullName));

                if (environment.IsDevelopment())
                {
                    options
                        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                }
            });

            services.AddScoped<IUnitOfWork>(sp =>
               sp.GetRequiredService<ShopDbContext>());

            AddRepositories(services);

            return services;

        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();

            return services;
        }
    }
}
