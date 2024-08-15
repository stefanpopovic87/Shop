using Shop.Application.Abstractions;
using Shop.Common;

namespace Shop.Application.ProductSizeQuantites.Delete
{
    public sealed record DeleteProductSizeQuantityCommand(int productId, int sizeId) : ICommand<Result<string>>;
}
