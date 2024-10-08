﻿using Shop.Application.Dtos;

namespace Shop.Application.Products.Create
{
    public  sealed record CreateProductRequest (
        string Name,
        string Description,
        decimal Price,
        string Code,
        int BrandId,
        int SubcategoryId,
        int GenderId,
        List<SizeQuantityDto> ProductSizeQuantities);
}
