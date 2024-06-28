using MediatR;
using Shop.Common;

namespace Shop.Application.ProductSize.Create
{
    public record CreateProductSizeCommand(
        int ProductId,
        int SizeId,
        int QuantityInStock) : IRequest<Result<(int ProductId, int SizeId)>>;
}
