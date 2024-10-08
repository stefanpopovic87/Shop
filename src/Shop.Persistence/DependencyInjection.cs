using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Shop.Application.Interfaces;
using Shop.Application.Interfaces.UnitOfWork;
using Shop.Domain.Entities;
using Shop.Persistence.Database;
using Shop.Persistence.Interceptors;
using Shop.Persistence.Repositories;
using System;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        private const string _productDBConnection = "ProductDBConnection";
        private const string _historyDBConnection = "HistoryDBConnection";
        private const string _orderDBConnection = "OrderDBConnection";
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            AddProductContext(services, configuration, environment);
            AddOrderContext(services, configuration, environment);
            AddHistoryContext(services, configuration, environment);

            AddProductRepositories(services);
            AddOrderRepositories(services);

            return services;
        }

        private static IServiceCollection AddProductContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddKeyedScoped<List<AuditEntry>>("Audit", (_, _) => []);

            services.AddDbContext<ProductDbContext>((serviceProvider, options) =>
            {
                var connectionString = configuration.GetConnectionString(_productDBConnection);
                options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(ProductDbContext).Assembly.FullName));
                var auditEntries = serviceProvider.GetRequiredKeyedService<List<AuditEntry>>("Audit");
                var historyContext = serviceProvider.GetRequiredService<HistoryDbContext>();

                options.AddInterceptors(new AuditInterceptor(auditEntries, historyContext));

                ConfigureLogging(options, environment);

            });

            services.AddScoped<IProductUnitOfWork>(sp =>
               sp.GetRequiredService<ProductDbContext>());

            return services;
        }

        private static IServiceCollection AddOrderContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddKeyedScoped<List<AuditEntry>>("Audit", (_, _) => []);

            services.AddDbContext<OrderDbContext>((serviceProvider, options) =>
            {
                var connectionString = configuration.GetConnectionString(_orderDBConnection);
                options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName));
                var auditEntries = serviceProvider.GetRequiredKeyedService<List<AuditEntry>>("Audit");
                var historyContext = serviceProvider.GetRequiredService<HistoryDbContext>();

                options.AddInterceptors(new AuditInterceptor(auditEntries, historyContext));

                ConfigureLogging(options, environment);

            });

            services.AddScoped<IOrderUnitOfWork>(sp =>
               sp.GetRequiredService<OrderDbContext>());

            return services;
        }



        private static IServiceCollection AddHistoryContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<HistoryDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(_historyDBConnection);
                options.UseNpgsql(connectionString, npgsqlOptions => npgsqlOptions.MigrationsAssembly(typeof(HistoryDbContext).Assembly.FullName));

                ConfigureLogging(options, environment);

            });

            services.AddScoped<IHistoryUnitOfWork>(sp =>
               sp.GetRequiredService<HistoryDbContext>());

            return services;
        }

        private static IServiceCollection AddProductRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IProductSizeQuantityRepository, ProductSizeQuantityRepository>();
            return services;
        }

        private static IServiceCollection AddOrderRepositories(this IServiceCollection services)
        {
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            return services;
        }

        private static void ConfigureLogging(DbContextOptionsBuilder options, IHostEnvironment environment)
        {           
            options
                .LogTo(Log.Logger.Information, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();            
        }
    }
}
