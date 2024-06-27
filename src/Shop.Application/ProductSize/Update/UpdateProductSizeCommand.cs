using MediatR;
using Shop.Common;

namespace Shop.Application.ProductSize.Update
{
    public record UpdateProductSizeCommand(
        int ProductId,
        int SizeId,
        int QuantityInStock) : IRequest<Result<string>>;
}
