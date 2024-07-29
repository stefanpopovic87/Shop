using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.ProductSizeQuantity.Update
{
    public sealed record UpdateProductSizeQuantityCommand(int ProductId, int SizeId, int QuantityInStock) : ICommand<Result<string>>;
}
