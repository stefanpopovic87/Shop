using MediatR;
using Shop.Common;

namespace Shop.Application.Product.Update
{
    public record UpdateProductCommand(
        int Id,
        string Name,
        string Description,
        decimal Price,
        string? PictureUrl) : IRequest<Result<string>>;
}
