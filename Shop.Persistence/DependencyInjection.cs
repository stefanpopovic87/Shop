using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Domain.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories;

namespace Shop.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ShopDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ShopConnection"),
            sqlOptions => sqlOptions.MigrationsAssembly(typeof(ShopDbContext).Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork>(sp =>
            sp.GetRequiredService<ShopDbContext>());
            return services;
        }
    }
}
