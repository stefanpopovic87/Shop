using MediatR;
using Shop.Common;

namespace Shop.Application.ProductSize.Delete
{
    public record DeleteProductSizeCommand(int ProductId, int SizeId) : IRequest<Result<string>>;
}
