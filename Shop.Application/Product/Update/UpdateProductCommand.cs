using MediatR;

namespace Shop.Application.Product.Update
{
    public record UpdateProductCommand(
        int Id,
        string Name,
        string Description,
        decimal Price,
        string? PictureUrl) : IRequest;
}
