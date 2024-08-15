using Shop.Application.Dtos;

namespace Shop.Application.Products.Update
{
    public sealed record UpdateProductRequest(
        string Name,
        string Description,
        decimal Price,
        string Code,
        int BrandId,
        int SubcategoryId,
        int GenderId,
        List<SizeQuantityDto> ProductSizeQuantities);
}
