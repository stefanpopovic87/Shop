using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Shop.Application.Interfaces;
using Shop.Domain.Entities;
using Shop.Persistence.Database;
using Shop.Persistence.Interceptors;
using Shop.Persistence.Repositories;
using System;

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
            services.AddKeyedScoped<List<AuditEntry>>("Audit", (_, _) => []);

            services.AddDbContext<ProductDbContext>((serviceProvider, options) =>
            {
                var connectionString = configuration["ConnectionStrings:Shop:ProductDb"];
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

        private static IServiceCollection AddHistoryContext(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddDbContext<HistoryDbContext>(options =>
            {
                var connectionString = configuration["ConnectionStrings:Shop:HistoryDb"];
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
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IGenderRepository, GenderRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IProductSizeQuantityRepository, ProductSizeQuantityRepository>();

            return services;
        }

        private static void ConfigureLogging(DbContextOptionsBuilder options, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                options
                    .LogTo(Log.Logger.Information, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
        }
    }
}
