using Shop.Application.Abstractions;
using Shop.Application.Dtos;
using Shop.Common;

namespace Shop.Application.ProductSizeQuantity.Get
{
    public sealed record GetProductSizeQuantityByIdQuery(int ProductId, int SizeId) : IQuery<Result<ProductSizeQuantityDto>>;
}
