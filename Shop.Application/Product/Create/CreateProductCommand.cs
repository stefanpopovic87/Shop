using MediatR;

namespace Shop.Application.Product.Create
{
    public record CreateProductCommand(
        string Name, 
        string Description, 
        decimal Price, 
        string? PictureUrl) : IRequest<int>;
}
