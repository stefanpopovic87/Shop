using Shop.Application.Abstractions;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.Product.Update
{
    public record UpdateProductCommand(
        int Id,
        string Name,
        string Description,
        decimal Price,
        string Code,
        int BrandId,
        int SubcategoryId,
        int GenderId,
        List<SizeQuantityDto> ProductSizeQuantities) : ICommand<Result<string>>;
}
