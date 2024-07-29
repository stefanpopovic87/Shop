using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.ProductSizeQuantity.Create
{
    public sealed record CreateProductSizeQuantityCommand(
        int ProductId,
        int SizeId,
        int QuantityInStock) : ICommand<Result<(int ProductId, int SizeId)>>;

}
