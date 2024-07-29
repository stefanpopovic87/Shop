using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.ProductSizeQuantity.Update
{
    public sealed record ActivateProductSizeQuantityCommand(int ProductId, int SizeId) : ICommand<Result<string>>;
}
