﻿using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Application.Interfaces;
using Shop.Persistence.Database;
using Shop.Persistence.Repositories.Base;

namespace Shop.Persistence.Repositories
{
    internal sealed class SizeRepository : BaseRepository<Size, ProductDbContext>, ISizeRepository
    {
        public SizeRepository(ProductDbContext context)
            : base(context) 
        {

        }

        public async Task<List<Size>> GetAllByCategoryIdAsync(int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Sizes.Where(s => s.CategoryId == categoryId).ToListAsync(cancellationToken);
        }

        public async Task<bool> UniqueNameInCategoryAsync(string name, int categoryId, CancellationToken cancellationToken)
        {
            return await _context.Sizes.AnyAsync(s => s.Name == name && s.CategoryId == categoryId, cancellationToken);
        }
    }
}
