using Shop.Application.Abstractions;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.Products.Create
{
    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        string Code,
        int BrandId,
        int SubcategoryId,
        int GenderId,
        List<SizeQuantityDto> ProductSizeQuantities) : ICommand<Result<int>>;
}
