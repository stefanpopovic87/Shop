﻿using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities.Products;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class ProductRepository : BaseRepository<Product, ProductDbContext>, IProductRepository
    {
        public ProductRepository(ProductDbContext context)
            : base(context)
        {
        }

        public async Task<List<Product>> GetAllIdIncludeSizeQuantitiesAsync(CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(x => x.SizeQuantities)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdIncludeSizeQuantitiesAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Products
                .Include(x => x.SizeQuantities)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
