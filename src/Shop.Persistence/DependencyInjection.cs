using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            AddProductContext(services, configuration, environment);

            AddHistoryContext(services, configuration, environment);

            AddProductRepositories(services);

            return services;

        }

        private static IServiceCollection AddProductContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("ProductDBConnection");
                options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(ProductDbContext).Assembly.FullName));

                if (environment.IsDevelopment())
                {
                    options
                        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                }
            });

            services.AddScoped<IProductUnitOfWork>(sp =>
               sp.GetRequiredService<ProductDbContext>());

            return services;
        }

        private static IServiceCollection AddHistoryContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<HistoryDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("HistoryDBConnection");
                options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(HistoryDbContext).Assembly.FullName));

                if (environment.IsDevelopment())
                {
                    options
                        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                        .EnableSensitiveDataLogging()
                        .EnableDetailedErrors();
                }
            });

            services.AddScoped<IHistoryUnitOfWork>(sp =>
               sp.GetRequiredService<HistoryDbContext>());

            return services;
        }




        private static IServiceCollection AddProductRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IProductSizeQuantityRepository, ProductSizeQuantityRepository>();

            return services;
        }
    }
}
