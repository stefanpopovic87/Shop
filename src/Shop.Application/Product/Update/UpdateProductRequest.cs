using Shop.Application.Dtos;

namespace Shop.Application.Product.Update
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
