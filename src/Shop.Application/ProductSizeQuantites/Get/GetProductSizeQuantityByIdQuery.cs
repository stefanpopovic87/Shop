using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.ProductSizeQuantites.Get
{
    public sealed record GetProductSizeQuantityByIdQuery(int ProductId, int SizeId) : IQuery<Result<GetProductSizeQuantityByIdResponse>>;
}
